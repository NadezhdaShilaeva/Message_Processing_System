namespace Application.Dto
{
    public record ManagerDto(Guid id, string name, IReadOnlyCollection<EmployeeDto> subordinates);
}
