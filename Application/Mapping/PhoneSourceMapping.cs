using Application.Dto;
using DataAccess.Models;

namespace Application.Mapping
{
    public static class PhoneSourceMapping
    {
        public static PhoneSourceDto AsDto(this PhoneSource phoneSource)
        {
            return new PhoneSourceDto(phoneSource.Id, phoneSource.PhoneMessages.Select(m => m.AsDto()).ToArray());
        }
    }
}
