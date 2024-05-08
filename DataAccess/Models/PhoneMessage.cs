namespace DataAccess.Models
{
    public class PhoneMessage : Message
    {
        public PhoneMessage(Guid id, DateTime dateTime, MessageState messageState, string text)
            : base(id, dateTime, messageState)
        {
            Text = text;
        }

        protected PhoneMessage() { }

        public string Text { get; set; }
    }
}
