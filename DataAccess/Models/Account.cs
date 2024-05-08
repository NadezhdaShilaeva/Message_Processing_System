namespace DataAccess.Models
{
    public class Account
    {
        public Account(Guid id, string login, string password)
        {
            Id = id;
            Login = login;
            Password = password;
            MessageSources = new List<MessageSource>();
            Reports = new List<Report>();
        }

        protected Account() { }

        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public AccountRole Role { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<MessageSource> MessageSources { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
