using System.Data;
using Core.Domain;
using BillingInfoDomain = Core.Domain.BillingInfo.BillingInfo;
using ContactInfoDomain = Core.Domain.ContactInfo.ContactInfo;
using ReceiverDomain = Core.Domain.Entity.Receiver.EntityReceiver;

namespace Repository.Entity.Receiver
{
    public class ReceiverEntity : EntityEntity
    {
        public ReceiverEntity(ulong? id, ulong billingInfoRef, ulong contactInfoRef) : base(id, billingInfoRef, contactInfoRef) { }

        public ReceiverDomain ToDomain(BillingInfoDomain billingInfo, ContactInfoDomain contactInfo)
        {
            return new ReceiverDomain(
                new SimpleObjectIdentifier(Id ?? throw new DataException("ReceiverEntity Id is null")),
                billingInfo,
                contactInfo
            );
        }

        public static ReceiverEntity FromDomain(ReceiverDomain domain)
        {
            return new ReceiverEntity(
                domain.Id.Value,
                domain.BillingInfo.Id.Value,
                domain.ContactInfo.Id.Value
            );
        }
    }
}