using FoodMart.POS.Shared.SeedWork;

namespace FoodMart.POS.Shared.AggregateEntities.CustomerAggregate
{
    public class ContactInformation(string email, string phoneNumber, string mobileNumber) : ValueObject
    {
        public string Email { get; } = email;
        public string PhoneNumber { get; } = phoneNumber;
        public string MobileNumber { get; } = mobileNumber;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Email;
            yield return PhoneNumber;
            yield return MobileNumber;
        }
    }
}