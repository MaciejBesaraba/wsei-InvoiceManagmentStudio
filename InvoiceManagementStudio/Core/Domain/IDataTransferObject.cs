namespace InvoiceManagementStudio.Core.Domain
{
    // TODO ArBy, Solid => to repo?
    /// <summary>
    /// Marks objects as Data Transfer. Constrains implementation of data transfer.
    /// </summary>
    /// <typeparam name="TDo">Type of object to convert into</typeparam>
    public interface IDataTransferObject<out TDo>
    {
        /// <summary>
        /// Converts dto object into domain
        /// </summary>
        /// <returns>Domain object of generically specified type</returns>
        TDo ToDomain();
    }

}
