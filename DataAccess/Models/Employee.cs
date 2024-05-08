namespace DataAccess.Models
{
    public abstract class Employee
    {
        public Employee(Guid id, string name)
        {
            Id = id;
            Name = name;
            Accounts = new List<Account>();
        }

        protected Employee() { }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
