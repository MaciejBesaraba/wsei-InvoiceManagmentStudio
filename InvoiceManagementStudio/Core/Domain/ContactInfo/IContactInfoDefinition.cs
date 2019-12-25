using InvoiceManagementStudio.Core.Domain.Entity;

namespace InvoiceManagementStudio.Core.Domain.ContactInfo
{
    // TODO define "subject"
    /// <summary>
    /// Represents set of information needed to contact a subject
    /// </summary>
    public interface IContactInfoDefinition
    {

        /// <summary>
        /// Unique identifier for ContactInfo instance
        /// </summary>
        IObjectIdentifier<ulong> Id { get; }

        /// <summary>
        /// Subject's email
        /// </summary>
        string Email { get; }

        // TODO Localization
        /// <summary>
        /// Subject's phone number
        /// </summary>
        string Phone { get; }

        // TODO Localization
        /// <summary>
        /// Subject's mobile phone number
        /// </summary>
        string Mobile { get; }

        // TODO define "subject"
        /// <summary>
        /// Subject's official job/education title
        /// </summary>
        string Title { get; }

        // TODO define "subject"
        /// <summary>
        /// Subject's sex
        /// </summary>
        ESex Sex { get; }

        // TODO define "subject"
        /// <summary>
        /// Subject's name
        /// </summary>
        string Name { get; }

        // TODO define "subject"
        /// <summary>
        /// Subject's surname
        /// </summary>
        string Surname { get; }
    }

}
