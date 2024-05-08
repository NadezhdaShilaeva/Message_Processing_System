using Application.Dto;
using DataAccess.Models;

namespace Application.Mapping
{
    public static class MessageMapping
    {
        public static MessageDto AsDto(this Message message)
        {
            return new MessageDto(message.Id, message.DateTime, message.MessageState.ToString());
        }
    }
}
