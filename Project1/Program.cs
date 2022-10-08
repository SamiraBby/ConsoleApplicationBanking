using Project1.Services.Implementations;
using Project1.Models;
using System;
using Project1.Data;

namespace Project1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            Console.WriteLine("******* MANAGER LOGIN *******");
            Console.Write("Please enter Manager Username: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            manager.UserName = Console.ReadLine();
            Console.ResetColor();

            Console.Write("Please enter Manager Password: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            manager.Password = Console.ReadLine();
            Console.ResetColor();
            Console.WriteLine();
            if (manager.UserName == "Samira" && manager.Password=="1234")
            {
                Console.WriteLine("Hello " + manager.UserName);

                Console.WriteLine();
                Console.WriteLine("Choose operation:");
                Console.WriteLine("1 - Branch ");
                Console.WriteLine("2 - Employee. ");
                Console.WriteLine();
                int a = int.Parse(Console.ReadLine());
                DoWork(a);
            }
            else
            {
                Console.WriteLine("Wrong username or password");
            }
           
            Console.WriteLine();
        }
        
        static void DoWork(int x)
        {
            while (true)
            {

                
                if (x == 1 || x == 2)
                {
                    Bank<Branch> branch = new Bank<Branch>();
                    Bank<Employee> employees = new Bank<Employee>();
                    Manager manager = new Manager();

                    BranchService branchService = new BranchService(branch, employees);
                    var dataForBranch = SeedDatabase.SeedBranch();
                    branch.Datas = dataForBranch;

                    EmployeeService employeeService = new EmployeeService(employees);
                    var dataForEmployee = SeedDatabase.SeedEmployee();
                    employees.Datas = dataForEmployee;

                    switch (x)
                    {
                        case 1:
                            Console.WriteLine("Look at Menu below and choose operation:");
                            Console.WriteLine("please. add number:");
                            Console.WriteLine("1 - Create Branch ");
                            Console.WriteLine("2 - Update Branch ");
                            Console.WriteLine("3 - Delete Branch ");
                            Console.WriteLine("4 - Get Branch ");
                            Console.WriteLine("5 - GetAll Branch ");
                            Console.WriteLine("6 - GetProfit Branch ");
                            Console.WriteLine("7 - HireEmployee Branch ");
                            Console.WriteLine("8 - TransferEmployee Branch ");
                            Console.WriteLine("9 - TransferMoney Branch ");
                            Console.WriteLine();
                            int b = int.Parse(Console.ReadLine());

                            Console.WriteLine();
                            switch (b)
                            {
                                case 1:
                                    Console.WriteLine("Please add Branch name :");
                                    string create_branch_name = Console.ReadLine();
                                    Console.WriteLine("Please add Branch address :");
                                    string create_branch_address = Console.ReadLine();
                                    Console.WriteLine("Please add Branch budget :");
                                    int create_branch_budget = int.Parse(Console.ReadLine());
                                    Branch branch1 = new Branch(create_branch_name, create_branch_address, create_branch_budget);
                                    Console.Write("New Branch : ");
                                    Branch create_branch = branchService.Create(branch1);
                                    Console.WriteLine(create_branch.Name + "," + create_branch.Address + "," + create_branch.Budget);
                                    break;
                                case 2:
                                    Console.WriteLine("Please enter Branch name :");
                                    string update_branch_name = Console.ReadLine();
                                    Console.WriteLine("Please update Branch budget :");
                                    int update_branch_budget = int.Parse(Console.ReadLine());
                                    var update_branch = branchService.Get(update_branch_name);
                                    update_branch.Budget = update_branch_budget;
                                    Console.Write("Updated Branch budget: ");
                                    Branch update_branch2 = branchService.Update(update_branch_name, update_branch);
                                    Console.WriteLine(update_branch2.Name + "," + update_branch2.Address + "," + update_branch2.Budget);
                                    break;
                                case 3:
                                    Console.WriteLine("Enter Branch name :");
                                    string delete_branch_name = Console.ReadLine();
                                    Console.WriteLine();

                                    branchService.Delete(delete_branch_name);
                                    Console.WriteLine("Delete Branch :" + delete_branch_name);
                                    break;
                                case 4:
                                    Console.WriteLine("Please enter Branch name :");
                                    string get_branch_name = Console.ReadLine();
                                    var branch2 = branchService.Get(get_branch_name);
                                    Console.Write("Get Branch :");
                                    Console.WriteLine(branch2.Name + "," + branch2.Address + "," + branch2.Budget);
                                    break;
                                case 5:
                                    Console.WriteLine("All Branchs :");
                                    branchService.GetAll();
                                    break;
                                case 6:
                                    Console.WriteLine("Please enter Branch name :");
                                    string getprofit_branch_name = Console.ReadLine();
                                    int profit = branchService.GetProfit(getprofit_branch_name);
                                    Console.Write("Get profit Branch :");
                                    Console.WriteLine(getprofit_branch_name + " budget " + profit);
                                    break;
                                case 7:
                                    Console.WriteLine("Please enter Employee Fullname :");
                                    string employee_name = Console.ReadLine();
                                    Console.WriteLine("Please enter Branch name :");
                                    string hire_branch_name = Console.ReadLine();
                                    Console.WriteLine();
                                    branchService.HireEmployee(employee_name, hire_branch_name);
                                    break;
                                case 8:
                                    Console.WriteLine("Please enter Employee Fullname :");
                                    string employee_fullname = Console.ReadLine();
                                    Console.WriteLine("Please enter current Branch name :");
                                    string current_branch_name = Console.ReadLine();
                                    Console.WriteLine("Please enter transfer Branch name :");
                                    string transfer_branch_name = Console.ReadLine();
                                    branchService.TransferEmployee(employee_fullname, current_branch_name, transfer_branch_name);

                                    break;
                                case 9:
                                    Console.WriteLine("Please enter current Branch name:");
                                    string transfermoney_current_branch = Console.ReadLine();
                                    Console.WriteLine("Please enter transfered Branch name :");
                                    string transfermoney_transfered_branch = Console.ReadLine();
                                    Console.WriteLine("Please enter amount :");
                                    int transfermoney_amount = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Transfered money : ");
                                    Branch branchother = branchService.TransferMoney(transfermoney_current_branch, transfermoney_transfered_branch, transfermoney_amount);
                                    Console.WriteLine(branchother.Name + "," + branchother.Address + "," + branchother.Budget);
                                    break;

                                default:
                                    break;
                            }
                            break;
                        case 2:
                            Console.WriteLine("Look at Menu below and choose operation:");
                            Console.WriteLine("please. add number:");
                            Console.WriteLine("1 - Create Employee ");
                            Console.WriteLine("2 - Update Employee ");
                            Console.WriteLine("3 - Delete Employee ");
                            Console.WriteLine("4 - Get Employee ");
                            Console.WriteLine("5 - GetAll Employee ");
                            Console.WriteLine();
                            int c = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                            switch (c)
                            {
                                case 1:
                                    Console.WriteLine("Please add Employee name :");
                                    string create_employee_name = Console.ReadLine();
                                    Console.WriteLine("Please add Employee surname :");
                                    string create_employee_surname = Console.ReadLine();
                                    Console.WriteLine("Please add Employee salary :");
                                    int create_employee_salary = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Please add Employee profession :");
                                    string create_employee_profession = Console.ReadLine();
                                    Console.WriteLine("Please add Employee Branch name :");
                                    string create_employee_branchname = Console.ReadLine();

                                    Employee emp = new Employee(create_employee_name, create_employee_surname,
                                                                create_employee_salary, create_employee_profession, create_employee_branchname);
                                    Console.Write("New Employee : ");
                                    Employee create_emp = employeeService.Create(emp);
                                    Console.WriteLine();
                                    Console.WriteLine(create_emp.FullName + "," + create_emp.Salary + "," + create_emp.Salary + "," + create_emp.Profession);
                                    break;
                                case 2:
                                    Console.WriteLine("Please enter Employee Fullname :");
                                    string update_employee_name = Console.ReadLine();
                                    Console.WriteLine("Please update Employee salary :");
                                    int update_employee_salary = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Please enter Employee profession :");
                                    string update_employee_profession = Console.ReadLine();
                                    var update_employee = employeeService.Get(update_employee_name);
                                    update_employee.Salary = update_employee_salary;
                                    update_employee.Profession = update_employee_profession;
                                    Console.Write("Updated Branch budget: ");
                                    Employee update_employee2 = employeeService.Update(update_employee_name, update_employee);
                                    Console.WriteLine(update_employee2.FullName + "," + update_employee2.Salary + "," + update_employee2.Profession);
                                    break;
                                case 3:
                                    Console.WriteLine("Please enter Employee Fullname :");
                                    string delete_employee_name = Console.ReadLine();
                                    Console.WriteLine();

                                    employeeService.Delete(delete_employee_name);
                                    Console.WriteLine("Deleted Employee :" + delete_employee_name);
                                    break;
                                case 4:
                                    Console.WriteLine("Please enter Employee Fullname :");
                                    string get_employee_name = Console.ReadLine();
                                    var employee = employeeService.Get(get_employee_name);
                                    Console.Write("Get Employee :");
                                    Console.WriteLine(employee.FullName + "," + employee.Salary + "," + employee.Profession + "," + employee.BranchName);
                                    break;
                                case 5:
                                    Console.WriteLine("All Employees :");
                                    employeeService.GetAll();
                                    break;
                                default:
                                    break;
                            }
                            break;
                        default:

                            break;
                    }

                }
                else
                {
                    Console.WriteLine("Please enter 1 or 2");
                    int y = Convert.ToInt32(Console.ReadLine());
                    DoWork(y);
                }
            }
        }
    } 
            
}

