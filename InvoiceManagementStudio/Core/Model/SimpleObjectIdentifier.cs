using InvoiceManagementStudio.Core.Definition;


namespace InvoiceManagementStudio.Core.Model
{

    public class SimpleObjectIdentifier : IObjectIdentifier<ulong>
    {
        private ulong id;

        public ulong Id => id;


        SimpleObjectIdentifier(ulong id)
        {
            this.id = id;
        }


        public override string ToString()
        {
            return Id.ToString();
        }

    }

}
