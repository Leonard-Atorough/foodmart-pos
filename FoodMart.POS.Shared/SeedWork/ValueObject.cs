using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMart.POS.Shared.SeedWork
{
    public abstract class ValueObject
    {
        public override bool Equals(object? obj)
        {

            if (obj == null || GetType() != obj.GetType()) return false;

            var valObject = (ValueObject)obj;

            return GetEqualityComponents().SequenceEqual(valObject.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents().
                Aggregate(1, (current, obj) =>
                {
                    unchecked
                    {
                        return current * 23 + (obj?.GetHashCode() ?? 0);
                    }
                });
        }

        public static bool operator ==(ValueObject a, ValueObject b)
        {
            if (a is null &&  b is null) return true;

            if (a is null || b is null) return false;

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject a, ValueObject b)
        {
            return !(a == b);
        }

        protected abstract IEnumerable<object> GetEqualityComponents();
    }
}
