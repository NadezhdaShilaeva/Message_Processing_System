namespace Application.Exceptions
{
    public class ReportException : ApplicationException
    {
        private ReportException(string message)
            : base(message) { }

        public static ReportException ReportNotFound(Guid id)
        {
            return new ReportException($"The report {id} was not found.");
        }
    }
}
