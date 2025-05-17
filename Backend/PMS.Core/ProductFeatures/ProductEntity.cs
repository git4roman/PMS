using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using PMS.Core.CategoryFeatures;

namespace PMS.Core.ProductFeatures
{
    public class ProductEntity
    {
        protected ProductEntity()
        {
        }
        public ProductEntity(string Name, string Description, string ImageUrl, int CategoryId, int Quantity,int Price)
        {
            Guid = Guid.NewGuid();
            this.Name = Name;
            this.Description = Description;
            this.ImageUrl = ImageUrl;
            this.CategoryId = CategoryId;
            CreatedDate = DateOnly.FromDateTime(DateTime.Now);
            CreatedTime = TimeOnly.FromDateTime(DateTime.Now);
            Status = ProductStatusEnum.Active;
            this.Quantity = Quantity;
            this.Price = Price;
        }
        public ProductEntity(int Id,string Name, string Description, string ImageUrl, int CategoryId, int Quantity,int Price): this(Name,Description,ImageUrl,CategoryId,Quantity,Price)
        {
            this.Id =Id;
        }
        public int Id { get; protected set; }
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        [JsonIgnore]
        public virtual CategoryEntity Category { get; set; }
        public DateOnly CreatedDate { get; private set; }
        public DateOnly UpdatedDate { get; private set; }
        public TimeOnly UpdatedTime { get; private set; }
        public TimeOnly CreatedTime { get; private set; }

        public string Status { get; set; }

        public void Activate()
        {
            Status= ProductStatusEnum.Active;
        }
        public void Deactivate()
        {
            Status = ProductStatusEnum.InActive;
        }
        public bool IsActive() {  
            return Status == ProductStatusEnum.Active;
        }
        public void UpdateTimestamp()
        {
            UpdatedDate = DateOnly.FromDateTime(DateTime.Now);
            UpdatedTime = TimeOnly.FromDateTime(DateTime.Now);
        }


    }
}
