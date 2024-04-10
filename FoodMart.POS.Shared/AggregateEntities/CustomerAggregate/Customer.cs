using FoodMart.POS.Shared.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMart.POS.Shared.AggregateEntities.CustomerAggregate
{
    public class Customer: BaseEntity, IAggreateRoot
    {
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public ContactInformation ContactInformation { get; set; }
        public Address Address { get; set; }

        public Customer(string firstName, string lastName, ContactInformation contactInformation, Address address)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentException($"'{nameof(firstName)}' cannot be null or empty.", nameof(firstName));
            }

            FirstName = firstName;
            LastName = lastName;
            ContactInformation = contactInformation;
            Address = address;
        }
    }
}
