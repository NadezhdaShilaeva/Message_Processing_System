using Application.Dto;
using DataAccess.Models;

namespace Application.Mapping
{
    public static class EmailMessageMapping
    {
        public static EmailMessageDto AsDto(this EmailMessage emailMessage)
        {
            return new EmailMessageDto(((Message)emailMessage).AsDto(), emailMessage.Text);
        }
    }
}
