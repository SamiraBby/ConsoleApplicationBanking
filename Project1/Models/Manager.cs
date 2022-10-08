namespace Project1.Models
{
    public class Manager : BaseModel
    {
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName => $"{this.Name} {Surname}";
    }
}
