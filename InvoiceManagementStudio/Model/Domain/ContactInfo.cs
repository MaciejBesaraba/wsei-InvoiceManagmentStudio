using System;
using InvoiceManagementStudio.Core.Definition;
using InvoiceManagementStudio.Core.Definition.ContactInfo;
using InvoiceManagementStudio.Core.Definition.Entity;



namespace InvoiceManagementStudio.Model.Domain
{

    public class ContactInfo : IContactInfoDefinition, IEquatable<ContactInfo>
    {
        public IObjectIdentifier<ulong> Id { get; }
        public string Email { get; }
        public string Phone { get; }
        public string Mobile { get; }
        public string Title { get; }
        public ESex Sex { get; }
        public string Name { get; }
        public string Surname { get; }


        public ContactInfo(
            IObjectIdentifier<ulong> id,
            string email,
            string phone,
            string mobile,
            string title,
            ESex sex,
            string name,
            string surname

        )
        {
            Id = id;
            Email = email;
            Phone = phone;
            Mobile = mobile;
            Title = title;
            Sex = sex;
            Name = name;
            Surname = surname;


        }


