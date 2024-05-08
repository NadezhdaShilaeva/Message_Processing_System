using Application.Dto;
using DataAccess.Models;

namespace Application.Mapping
{
    public static class AccountMapping
    {
        public static AccountDto AsDto(this Account account)
        {
            return new AccountDto(account.Id, account.Login, account.Password, account.Role.ToString());
        }
    }
}