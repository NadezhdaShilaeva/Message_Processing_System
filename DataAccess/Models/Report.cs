namespace DataAccess.Models
{
    public class Report
    {
        public Report(Guid id, DateTime dateTime, TimeSpan interval, Guid managerId, int countOfProcessedMessages, int countOfReceivedMessages, int totalCountOfMessages)
        {
            Id = id;
            DateTime = dateTime;
            Interval = interval;
            ManagerId = managerId;
            CountOfProcessedMessages = countOfProcessedMessages;
            CountOfReceivedMessages = countOfReceivedMessages;
            TotalCountOfMessages = totalCountOfMessages;
        }

        protected Report() { }

        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public TimeSpan Interval { get; set; }
        public Guid ManagerId { get; set; }
        public int CountOfProcessedMessages { get; set; }
        public int CountOfReceivedMessages { get; set; }
        public int TotalCountOfMessages { get; set; }
    }
}
