namespace DataAccess.Models
{
    public class MessengerSource : MessageSource
    {
        public MessengerSource(Guid id)
            : base(id)
        {
            MessengerMessages = new List<MessengerMessage>();
        }

        protected MessengerSource() { }

        public virtual ICollection<MessengerMessage> MessengerMessages { get; set; }
    }
}
