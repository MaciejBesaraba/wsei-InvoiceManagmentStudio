namespace Core.Domain.Payment
{
    /// <summary>
    /// Type of payment used on invoice
    /// </summary>
    public enum EPaymentType
    {
        Cash,
        BankTransfer,
        InAdvance,

        #region BankCards
        CardMasterCard,
        CardMaestro,
        CardVisa,
        CardAmericanExpress
        #endregion
    }
}
