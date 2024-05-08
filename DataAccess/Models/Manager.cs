namespace DataAccess.Models
{
    public class Manager : Employee
    {
        public Manager(Guid id, string name)
            : base(id, name)
        {
            Subordinates = new List<Employee>();
        }

        protected Manager() { }

        public virtual ICollection<Employee> Subordinates { get; set; }
    }
}
