namespace Project1.Models
{
    public class Employee : BaseModel
    {
        public string Surname { get; set; }
        public int Salary { get; set; }
        public string Profession { get; set; }
        public string BranchName { get; set; }
        public string FullName => $"{this.Name} {Surname}";
        public Employee(string name, string surname, int salary, string profession,string branchName)
        {
            this.Name = name;
            this.Surname = surname;
            this.Salary = salary;
            this.Profession = profession;
            this.BranchName = branchName;
        }

    }
}
