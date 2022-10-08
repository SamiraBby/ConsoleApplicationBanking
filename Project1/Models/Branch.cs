using System.Collections.Generic;

namespace Project1.Models
{
    public class Branch : BaseModel
    {
        public string Address { get; set; }
        public int Budget { get; set; }
        public List<Employee> Employees { get; set; }

        public Branch(string name, string address, int budget)
        {
            this.Name = name;
            this.Address = address;
            this.Budget = budget;
            this.Employees = new List<Employee>();
        }
    
    }
}
