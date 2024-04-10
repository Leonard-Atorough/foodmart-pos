using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMart.POS.Shared.SeedWork
{
    public abstract class BaseEntity
    {
        public int Id { get; protected set; }

        protected BaseEntity() { }
        public BaseEntity(int id) { Id = id; }

        public override bool Equals(object? obj)
        {
            if (obj == null) throw new ArgumentNullException();

            if (obj is not BaseEntity other) return false;

            if (ReferenceEquals(this, other)) return true;

            if (GetUnproxiedType(this) != GetUnproxiedType(other)) return false;

            if (Id.Equals(default) || other.Id.Equals(default)) return false;

            return Id.Equals(other.Id);
        }

        public static bool operator ==(BaseEntity left, BaseEntity right)
        {
            if (left is null && right is null) return true;

            if (left is null || right is null) return false;

            return left.Equals(right);
        }

        public static bool operator !=(BaseEntity left, BaseEntity right)
        {
            return !(left == right);
        }

        private static Type GetUnproxiedType(BaseEntity baseEntity)
        {
            return ObjectContext.GetObjectType(baseEntity.GetType());
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
