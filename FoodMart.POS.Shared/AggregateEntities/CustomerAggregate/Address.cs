using FoodMart.POS.Shared.SeedWork;

namespace FoodMart.POS.Shared.AggregateEntities.CustomerAggregate
{
    public class Address(string addressLine1, string addressLine2, string city, string region, string postalCode, string country) : ValueObject
    {
        public string AddressLine1 { get; } = addressLine1;
        public string AddressLine2 { get; } = addressLine2;
        public string City { get; } = city;
        public string Region { get; } = region;
        public string PostalCode { get; } = postalCode;
        public string Country { get; } = country;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return AddressLine1;
            yield return AddressLine2; 
            yield return City; 
            yield return Region; 
            yield return PostalCode; 
            yield return Country;
        }
    }
}