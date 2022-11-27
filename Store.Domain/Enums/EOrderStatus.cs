using System.ComponentModel;

namespace Store.Domain.Enums
{
    public enum EOrderStatus
    {
        [Description("Order Received")]
        Received = 1,

        [Description("Order in Process")]
        Processing = 2,

        [Description("Order sent")]
        Sent = 3
    }
}
