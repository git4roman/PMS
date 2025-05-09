using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Core.CategoryFeatures;

namespace PMS.Core.ProductFeatures
{
    public class ProductEntity
    {
        public ProductEntity(string Name, string Description, string ImageUrl, Guid CategoryId)
        {
            Guid = Guid.NewGuid();
            this.Name = Name;
            this.Description = Description;
            this.ImageUrl = ImageUrl;
            this.CategoryId = CategoryId;
            CreatedDate= DateOnly.FromDateTime(DateTime.Now);
            CreatedTime= TimeOnly.FromDateTime(DateTime.Now);
            Status= ProductStatusEnum.Active;
        }

        public int Id { get;protected set; }
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
        public DateOnly CreatedDate { get; set; }
        public TimeOnly CreatedTime { get; set; }

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
        

    }
}
