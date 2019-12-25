using System;
using InvoiceManagementStudio.Core.Domain;


namespace InvoiceManagementStudio.Model
{

    public class SimpleObjectIdentifier : IObjectIdentifier<ulong>, IEquatable<SimpleObjectIdentifier>
    {
        public ulong Id { get; }


        public SimpleObjectIdentifier(ulong id)
        {
            this.Id = id;
        }


        public override string ToString()
        {
            return Id.ToString();
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
            return Id == other.Id;
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
            return Id.GetHashCode();
        }

    }

}
