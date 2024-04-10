using FoodMart.POS.Shared.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMart.POS.Shared.AggregateEntities.UserAggregate
{
    public class User : BaseEntity, IAggreateRoot
    {
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set;} = string.Empty;
        public string Username { get; set; } = string.Empty;
        public bool IsAdmin { get; private set; }

        public User(string firstName, string lastName, string username, bool isAdmin)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            IsAdmin = isAdmin;
        }
    }
}
