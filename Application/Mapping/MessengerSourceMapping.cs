using Application.Dto;
using DataAccess.Models;

namespace Application.Mapping
{
    public static class MessengerSourceMapping
    {
        public static MessengerSourceDto AsDto(this MessengerSource messengerSource)
        {
            return new MessengerSourceDto(messengerSource.Id, messengerSource.MessengerMessages.Select(m => m.AsDto()).ToArray());
        }
    }
}
