using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DiscogsClient.Data.Query
{
    public enum DiscogsOrderStatusType
    {
        [Description("All")]
        All,

        [Description("New Order")]
        NewOrder,

        [Description("Buyer Contacted")]
        BuyerContacted,

        [Description("Invoice Sent")]
        InvoiceSent,

        [Description("Payment Pending")]
        PaymentPending,

        [Description("Payment Received")]
        PaymentRecived,

        [Description("Shipped")]
        Shipped,

        [Description("Merged")]
        Merged,

        [Description("Order Changed")]
        OrderChanged,

        [Description("Refund Sent")]
        RefundSent,

        [Description("Cancelled")]
        Cancelled,

        [Description("Cancelled (Non-Paying Buyer)")]
        CancelledNonPayingBuyer,

        [Description("Cancelled (Item Unavailable)")]
        CancelledItemUnavailable,

        [Description("Cancelled (Per Buyer's Request)")]
        CancelledPerBuyerRequest,

        [Description("Cancelled (Refund Received)")]
        CancelledRefundRecived
    }
}
