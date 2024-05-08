using Application.Dto;
using DataAccess.Models;

namespace Application.Mapping
{
    public static class EmailSourceMapping
    {
        public static EmailSourceDto AsDto(this EmailSource emailSource)
        {
            return new EmailSourceDto(emailSource.Id, emailSource.EmailMessages.Select(m => m.AsDto()).ToArray());
        }
    }
}
