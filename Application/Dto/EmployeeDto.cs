namespace Application.Dto
{
    public record EmployeeDto(Guid id, string name, IReadOnlyCollection<AccountDto> accounts);
}
