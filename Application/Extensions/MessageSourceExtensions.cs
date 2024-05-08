using DataAccess.Models;

namespace Application.Extensions
{
    public static class MessageSourceExtensions
    {
        public static IReadOnlyCollection<Message> FindMessages(this MessageSource source)
        {
            if (source is EmailSource)
            {
                var emailSource = source as EmailSource ?? throw new ArgumentNullException(nameof(source));
                return new List<Message>(emailSource.EmailMessages);
            }

            if (source is PhoneSource)
            {
                var phoneSource = source as PhoneSource ?? throw new ArgumentNullException(nameof(source));
                return new List<Message>(phoneSource.PhoneMessages);
            }

            if (source is MessengerSource)
            {
                var messengerSource = source as MessengerSource ?? throw new ArgumentNullException(nameof(source));
                return new List<Message>(messengerSource.MessengerMessages);
            }

            return new List<Message>();
        }
    }
}
