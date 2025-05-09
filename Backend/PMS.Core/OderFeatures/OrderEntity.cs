using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Core.CustomerFeatures;
using PMS.Core.OrderItemFeatures;

namespace PMS.Core.OderFeatures
{
    public class OrderEntity
    {
        public OrderEntity(string Name, string Description, int OrderItemId, int CustomerId, string OrderStatus, string DelieveryAddress)
        {
            Guid = Guid.NewGuid();
            this.Description = Description;
            this.OrderItemId = OrderItemId;
            this.CustomerId = CustomerId;
            this.OrderStatus = OrderStatusEnum.Pending;
            this.DelieveryAddress = DelieveryAddress;
        }

        public int Id { get; protected set; }
        public Guid Guid { get; set; }
        public string Description { get; set; }
        public int OrderItemId { get; set; }
        public OrderItemEntity OrderItemEntity { get; set; }
        public int CustomerId { get; set; }
        public CustomerEntity CustomerEntity { get; set; }

        public DateOnly CreatedDate { get; set; }
        public TimeOnly CreatedTime { get; set; }
        public string OrderStatus { get; set; }
        public string DelieveryAddress  { get; set; }

        public void OrderPending()
        {
            OrderStatus = OrderStatusEnum.Pending;

        }

        public void OrderConfirmed()
        {
            OrderStatus = OrderStatusEnum.Confirmed;
        }

        public void OrderDelievered()
        {
            OrderStatus= OrderStatusEnum.Delievered;
        }

        public void OrderShipped()
        {
            OrderStatus = OrderStatusEnum.Shipped;

        }
        public void OrderCancelled()
        {
            OrderStatus = OrderStatusEnum.Cancelled;

        }



    }
}
