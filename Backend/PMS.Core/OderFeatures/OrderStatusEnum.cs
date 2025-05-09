using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Core.OderFeatures
{
    public class OrderStatusEnum
    {
        public static readonly string Pending = "Pending";
        public static readonly string Confirmed = "Confirmed";
        public static readonly string Shipped = "Shipped";
        public static readonly string Delievered = "Delievered";
        public static readonly string Cancelled = "Cancelled";
    }
}
