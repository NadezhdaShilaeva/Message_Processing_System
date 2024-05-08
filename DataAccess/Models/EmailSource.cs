namespace DataAccess.Models
{
    public class EmailSource : MessageSource
    {
        public EmailSource(Guid id)
            : base(id)
        {
            EmailMessages = new List<EmailMessage>();
        }

        protected EmailSource() { }

        public virtual ICollection<EmailMessage> EmailMessages { get; set; }
    }
}
