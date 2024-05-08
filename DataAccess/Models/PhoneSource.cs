namespace DataAccess.Models
{
    public class PhoneSource : MessageSource
    {
        public PhoneSource(Guid id)
            : base(id)
        {
            PhoneMessages = new List<PhoneMessage>();
        }

        protected PhoneSource() { }

        public virtual ICollection<PhoneMessage> PhoneMessages { get; set; }
    }
}
