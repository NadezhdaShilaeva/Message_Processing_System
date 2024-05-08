using Application.Dto;
using DataAccess.Models;

namespace Application.Mapping
{
    public static class MessengerMessageMapping
    {
        public static MessengerMessageDto AsDto(this MessengerMessage messengerMessage)
        {
            return new MessengerMessageDto(((Message)messengerMessage).AsDto(), messengerMessage.Text);
        }
    }
}