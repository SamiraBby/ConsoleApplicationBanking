using Project1.Models;
using System.Collections.Generic;

namespace Project1.Data
{
    public class SeedDatabase
    {
        public static List<Employee> SeedEmployee()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee( "Samira", "Babayeva", 5500, "Financer","Filial 1"));
            employees.Add(new Employee( "Jale", "Huseynli", 500, "Developer", "Filial 2"));
            employees.Add(new Employee( "Fidan", "Huseynov", 9500, "Front-end Developer", "Filial 2"));
            employees.Add(new Employee( "Ayan", "Hesenov", 5000, "Team-Leader", "Filial 3"));

            return employees;
        }

        public static List<Branch> SeedBranch()
        {
            List<Branch> branches = new List<Branch>();
            branches.Add(new Branch( "Filial 1", "Azerbaijan - Baku", 550000));
            branches.Add(new Branch( "Filial 2", "Azerbaijan - Ganja", 250000));
            branches.Add(new Branch( "Filial 3", "Azerbaijan - Naxcivan", 1100000));

            return branches;
        }
    }
}
