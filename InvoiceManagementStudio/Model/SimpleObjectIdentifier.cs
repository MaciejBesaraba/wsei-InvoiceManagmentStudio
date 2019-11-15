using System;
using InvoiceManagementStudio.Core.Definition;


namespace InvoiceManagementStudio.Model
{

    public class SimpleObjectIdentifier : IObjectIdentifier<ulong>, IEquatable<SimpleObjectIdentifier>
    {
        private readonly ulong id;

        public ulong Id => id;


        SimpleObjectIdentifier(ulong id)
        {
            this.id = id;
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
            return id == other.id;
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
            return id.GetHashCode();
        }

    }

}
