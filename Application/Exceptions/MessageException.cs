namespace Application.Exceptions
{
    public class MessageException : ApplicationException
    {
        private MessageException(string message)
            : base(message) { }

        public static MessageException CannotProcessed(Guid messageId, Guid employeeId)
        {
            return new MessageException($"The message {messageId} cannot processed by the employee {employeeId}.");
        }

        public static MessageException NotReceived(Guid messageId)
        {
            return new MessageException($"The message {messageId} has not received yet.");
        }

        public static MessageException AlreadyProcessed(Guid messageId)
        {
            return new MessageException($"The message {messageId} has already been processed by other employee.");
        }
    }
}
