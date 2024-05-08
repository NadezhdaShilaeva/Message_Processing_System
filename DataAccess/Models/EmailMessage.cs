namespace DataAccess.Models
{
    public class EmailMessage : Message
    {
        public EmailMessage(Guid id, DateTime dateTime, MessageState messageState, string text)
            : base(id, dateTime, messageState)
        {
            Text = text;
        }

        protected EmailMessage() { }

        public string Text { get; set; }
    }
}
