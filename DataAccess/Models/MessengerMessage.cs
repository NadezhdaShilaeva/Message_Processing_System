namespace DataAccess.Models
{
    public class MessengerMessage : Message
    {
        public MessengerMessage(Guid id, DateTime dateTime, MessageState messageState, string text)
            : base(id, dateTime, messageState)
        {
            Text = text;
        }

        protected MessengerMessage() { }

        public string Text { get; set; }
    }
}
