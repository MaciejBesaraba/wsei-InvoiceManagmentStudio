namespace InvoiceManagementStudio.Core.Definition
{

    public interface IObjectIdentifier<out T>
    {
        T Id { get; }
    }

}
