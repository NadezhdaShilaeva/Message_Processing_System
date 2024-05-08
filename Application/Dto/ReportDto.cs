namespace Application.Dto
{
    public record ReportDto(Guid id, DateTime dateTime, TimeSpan interval, Guid managerId,
            int countOfProcessedMessages,
            int countOfReceivedMessages,
            int totalCountOfMessages);
}
