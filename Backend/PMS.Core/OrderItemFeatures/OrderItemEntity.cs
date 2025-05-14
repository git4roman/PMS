using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Core.OderFeatures;
using PMS.Core.ProductFeatures;

namespace PMS.Core.OrderItemFeatures
{
    public class OrderItemEntity
    {
        public OrderItemEntity(string Name, string Description, int Quantity, decimal UnitPrice, decimal TotalPrice, int ProductId, decimal ShippingCharge, int OrderId)
        {
            Guid = Guid.NewGuid();
            this.Name = Name;
            this.Description = Description;
            this.Quantity = Quantity;
            this.UnitPrice = UnitPrice;
            this.TotalPrice = TotalPrice;
            this.ProductId = ProductId;
            this.ShippingCharge = ShippingCharge;
            TotalPrice = (UnitPrice * Quantity) + ShippingCharge;
            this.OrderId = OrderId;
            CreatedDate = DateOnly.FromDateTime(new DateTime());
            CreatedTime = TimeOnly.FromDateTime(new DateTime());
        }

        public OrderItemEntity(int Id,string Name, string Description, int Quantity, decimal UnitPrice, decimal TotalPrice, int ProductId, decimal ShippingCharge, int OrderId): this(Name,Description, Quantity, UnitPrice, TotalPrice, ProductId, ShippingCharge,OrderId)
        {
            this.Id = Id;
        }

        public int Id { get; protected set; }
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal ShippingCharge { get; set; }
        public decimal TotalPrice { get; set; }

        public DateOnly CreatedDate { get; set; }
        public TimeOnly CreatedTime { get; set; }

        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }

        public int OrderId { get; set; }
        public OrderEntity Order { get; set; }  
    }
}
