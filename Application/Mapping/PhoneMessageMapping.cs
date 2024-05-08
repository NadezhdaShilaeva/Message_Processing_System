using Application.Dto;
using DataAccess.Models;

namespace Application.Mapping
{
    public static class PhoneMessageMapping
    {
        public static PhoneMessageDto AsDto(this PhoneMessage phoneMessage)
        {
            return new PhoneMessageDto(((Message)phoneMessage).AsDto(), phoneMessage.Text);
        }
    }
}
