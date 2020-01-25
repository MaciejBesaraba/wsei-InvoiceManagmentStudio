using System;

namespace Core.Domain
{

    public class SimpleObjectIdentifier : IObjectIdentifier<ulong>, IEquatable<SimpleObjectIdentifier>
    {
        public ulong Value { get; }


        public SimpleObjectIdentifier(ulong id)
        {
            this.Value = id;
        }


        public override string ToString()
        {
            return Value.ToString();
        }

        public bool Equals(SimpleObjectIdentifier other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            return obj.GetType() == GetType() && Equals((SimpleObjectIdentifier) obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

    }

}
