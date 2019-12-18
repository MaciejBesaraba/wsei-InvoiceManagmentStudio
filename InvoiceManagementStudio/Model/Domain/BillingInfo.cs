using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using InvoiceManagementStudio.Core.Definition;
using InvoiceManagementStudio.Core.Definition.Entity.Receiver;
using InvoiceManagementStudio.Core.Definition.Entity.Supplier;
using InvoiceManagementStudio.Core.Definition.Invoice;
using InvoiceManagementStudio.Core.Definition.Item;
using InvoiceManagementStudio.Core.Definition.Payment;
using InvoiceManagementStudio.Core.Definition.BillingInfo;
using InvoiceManagementStudio.Core.Definition.Address;


namespace InvoiceManagementStudio.Model.Domain
{

    public class BillingInfo : IBillingInfoDefinition, IEquatable<BillingInfo>
    {
        public IObjectIdentifier<ulong> Id { get; }
        public string CompanyName { get; }
        public string ZipCode { get; }
        public IAddressDefinition BillingAddress { get; }


        public BillingInfo(
            IObjectIdentifier<ulong> id,
            string companyName,
            string zipCode,
            IAddressDefinition billingAddress

        )
        {
            Id = id;
            CompanyName = companyName;
            ZipCode = zipCode;
            BillingAddress = billingAddress;


        }

        public override string ToString()
        {
            return "BillingInfo(" +
                       $"id={Id}, " +
                       $"companyName={CompanyName.ToString()}, " +
                       $"zipCode={ZipCode.ToString()}, " +
                       $"billingAddress={BillingAddress}, " +
                   ")";
        }


