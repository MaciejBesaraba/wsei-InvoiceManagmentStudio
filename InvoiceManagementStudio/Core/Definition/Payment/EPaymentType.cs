using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementStudio.Core.Definition.Payment
{

    /// <summary>
    /// Type of payment used on invoice
    /// </summary>
    public enum EType
    {
        Cash,

        #region BankCards
        CardMasterCard,
        CardMaestro,
        CardVisa,
        CardAmericanExpress,
        #endregion

        BankTransfer,
        InAdvance

    }

}