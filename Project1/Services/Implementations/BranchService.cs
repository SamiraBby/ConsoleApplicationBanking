using Project1.Data;
using Project1.Models;
using Project1.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Project1.Services.Implementations
{

    public class BranchService : IBranchService
    {
        public  Bank<Branch> BranchTable;
        public  Bank<Employee> EmployeeTable;

        public BranchService(Bank<Branch> BranchTable, Bank<Employee> EmployeeTable)
        {
            this.BranchTable = BranchTable;
            this.EmployeeTable = EmployeeTable;
        }

        public Branch Create(Branch branch)
        {
            
            Branch branch1 = new Branch(branch.Name, branch.Address, branch.Budget);
            BranchTable.Datas.Add(branch1);
            return branch1;
        }

        public void Delete(string name)
        {
            var result = BranchTable.Datas.Find(b => b.Name == name);
            result.IsDeleted = true;
            Console.WriteLine("All Branch : "); 
            GetAll();
        }

        public Branch Get(string name)
        {
            var branch = BranchTable.Datas.Find(b => b.Name == name);
            return branch;
        }

        public void GetAll()
        {
            List<Branch> branches = BranchTable.Datas.FindAll(b=>b.IsDeleted==false);
            int count = 1;
            foreach (var item in branches)
            {
                Console.WriteLine(count + ") " + item.Name+","+item.Address+ ","+ item.Budget);
                count++;
            }
        }

        public int GetProfit(string branchName)
        {
            var branch = BranchTable.Datas.Find(b => b.Name == branchName);
           
            var emploeebranch = EmployeeTable.Datas.FindAll(a => a.BranchName == branchName);

            int sumSalary = 0;
            foreach (var employee in emploeebranch)
            {
                sumSalary += employee.Salary;
            }

            branch.Budget = branch.Budget - sumSalary;

            return branch.Budget;
        }

        public bool HireEmployee(string employeeFullName, string branchName)
        {
            var employee = EmployeeTable.Datas.Find(e => e.FullName == employeeFullName);
            var branch = BranchTable.Datas.Find(b => b.Name == branchName);

          
            if (employee.Salary < branch.Budget)
            {
                branch.Employees.Add(employee);
                branch.Budget -= employee.Salary;

                Console.WriteLine(branch.Name+","+branch.Address+","+branch.Budget);
            }
            else
            {
                Console.WriteLine("The employee's salary cannot exceed the budget.");
            }
            return true;
        }

        public Branch TransferEmployee(string employeeFullName, string currentBranchName, string transferedBranchName)
        {
            var currentBranch = BranchTable.Datas.Find(b => b.Name == currentBranchName);
            var employee = EmployeeTable.Datas.Find(e => e.FullName == employeeFullName);
            var transferedBranch = BranchTable.Datas.Find(b => b.Name == transferedBranchName);
            transferedBranch.Employees.Add(employee);
            
            return transferedBranch;
        }
         
        public Branch TransferMoney(string currentBranchName, string transferedBranchName, int amount)
 {
            var currentBranch = BranchTable.Datas.Find(b => b.Name == currentBranchName);
            var transferedBranch = BranchTable.Datas.Find(b => b.Name == transferedBranchName);

            if (currentBranch.Budget > amount)
            {
                currentBranch.Budget -= amount;
                transferedBranch.Budget += amount;

                return transferedBranch;
            }
            else
            {
                Console.WriteLine("The budget of the branch cannot be less than the amount.");
            }
            return transferedBranch;
        }

        public Branch Update(string name,Branch branch)
        {
            var branch1 = BranchTable.Datas.Find(b => b.Name == name);
            branch1.Budget = branch.Budget;
            return branch1;
        }
    }
}
