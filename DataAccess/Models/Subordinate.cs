namespace DataAccess.Models
{
    public class Subordinate : Employee
    {
        public Subordinate(Guid id, string name)
            : base(id, name) { }

        protected Subordinate() { }
    }
}
