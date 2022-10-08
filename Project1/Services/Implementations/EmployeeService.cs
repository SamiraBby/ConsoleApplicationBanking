using Project1.Models;
using Project1.Services.Interfaces;
using System;
using System.Collections.Generic;
using Project1.Data;

namespace Project1.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        public  Bank<Employee> EmployeeTable;

        public EmployeeService(Bank<Employee> EmployeeTable)
        {
            this.EmployeeTable = EmployeeTable;
        }
        public Employee Create(Employee employee)
        {
            Employee employee1 = new Employee(employee.Name, employee.Surname, employee.Salary,employee.Profession,employee.BranchName);       
            EmployeeTable.Datas.Add(employee1);
            return employee1;
        }

        public void Delete(string fullname)
        {
            var result = EmployeeTable.Datas.Find(b => b.FullName == fullname);
            result.IsDeleted = true;
            Console.WriteLine("All Employee : ");
            GetAll();
        }

        public Employee Get(string name)
        {
            var employee = EmployeeTable.Datas.Find(b => b.FullName == name);
            return employee;
        }

        public void GetAll()
        {
            List<Employee> employees = EmployeeTable.Datas.FindAll(e=>e.IsDeleted==false);
            int count = 1;
            foreach (var item in employees)
            {

                Console.WriteLine(count+") "+ item.FullName + "," + item.Salary + "," + item.Profession + "," + item.BranchName);
                count++;
            }
        }

        public Employee Update(string name, Employee entity)
        {
            var employee = EmployeeTable.Datas.Find(b => b.FullName == name);
            employee.Profession = entity.Profession;
            employee.Salary = entity.Salary;
            return employee;
        }
    }
}
