using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Core.ProductFeatures;

namespace PMS.Core.OrderItemFeatures
{
    public class OrderItemEntity
    {
        public OrderItemEntity(string Name, string Description, int Quantity, decimal UnitPrice, decimal TotalPrice, int ProductId)
        {
            Guid = Guid.NewGuid();
            this.Name = Name;
            this.Description = Description;
            this.Quantity = Quantity;
            this.UnitPrice = UnitPrice;
            this.TotalPrice = TotalPrice;
            this.ProductId = ProductId;
        }

        public int Id { get; protected set; }
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }
    }
}
