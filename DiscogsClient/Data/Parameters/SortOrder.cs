using System;
using System.Collections.Generic;
using System.Text;

namespace DiscogsClient.Data.Parameters
{
    public enum OrderStatus
    {
        [DiscogsParameterValue("All")]
        All,

        [DiscogsParameterValue("New Order")]
        NewOrder,

        [DiscogsParameterValue("Buyer Contacted")]
        BuyerContacted,

        [DiscogsParameterValue("Invoice Sent")]
        InvoiceSent,

        [DiscogsParameterValue("Payment Pending")]
        PaymentPending,

        [DiscogsParameterValue("Payment Received")]
        PaymentRecived,

        [DiscogsParameterValue("Shipped")]
        Shipped,

        [DiscogsParameterValue("Merged")]
        Merged,

        [DiscogsParameterValue("Order Changed")]
        OrderChanged,

        [DiscogsParameterValue("Refund Sent")]
        RefundSent,

        [DiscogsParameterValue("Cancelled")]
        Cancelled,

        [DiscogsParameterValue("Cancelled (Non-Paying Buyer)")]
        CancelledNonPayingBuyer,

        [DiscogsParameterValue("Cancelled (Item Unavailable)")]
        CancelledItemUnavailable,

        [DiscogsParameterValue("Cancelled (Per Buyer's Request)")]
        CancelledPerBuyerRequest,

        [DiscogsParameterValue("Cancelled (Refund Received)")]
        CancelledRefundRecived
    }
}
