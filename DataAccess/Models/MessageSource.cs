namespace DataAccess.Models
{
    public abstract class MessageSource
    {
        public MessageSource(Guid id)
        {
            Id = id;
        }

        protected MessageSource() { }

        public Guid Id { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
