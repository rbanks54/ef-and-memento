using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.SharedKernel
{
    public abstract class Identity<T> : IEquatable<Identity<T>>, IIdentity<T>
    {
        protected Identity(T id)
        {
            Id = id;
        }

        public bool Equals(Identity<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualityComparer<T>.Default.Equals(Id, other.Id);
        }

        public T Id { get; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Identity<T>)obj);
        }

        public static bool operator ==(Identity<T> obj1, Identity<T> obj2)
        {
            return Equals(obj1, obj2);
        }

        public static bool operator !=(Identity<T> obj1, Identity<T> obj2)
        {
            return !Equals(obj1, obj2);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<T>.Default.GetHashCode(Id);
        }

        public override string ToString()
        {
            return GetType().Name + " [Id=" + Id + "]";
        }
    }

    public interface IIdentity<out T>
    {
        T Id { get; }
    }
}
