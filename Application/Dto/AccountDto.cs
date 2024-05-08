namespace Application.Dto
{
    public record AccountDto(Guid id, string login, string password, string role);
}
