namespace DataAccess.Models
{
    public abstract class Message
    {
        public Message(Guid id, DateTime dateTime, MessageState messageState)
        {
            Id = id;
            DateTime = dateTime;
            MessageState = messageState;
        }

        protected Message() { }

        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public MessageState MessageState { get; set; }
        public Employee? Employee { get; set; }
    }
}
