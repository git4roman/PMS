using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Core.CategoryFeatures
{
    public class CategoryCreateDto
    {
        public CategoryCreateDto( string name,
                        DateOnly createdDate, DateOnly updatedDate,
                        TimeOnly createdTime, TimeOnly updatedTime)
        {
            Name = name;      
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            CreatedTime = createdTime;
            UpdatedTime = updatedTime;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateOnly CreatedDate { get; protected set; }
        public DateOnly UpdatedDate { get; protected set; }
        public TimeOnly CreatedTime { get; protected set; }
        public TimeOnly UpdatedTime { get; protected set; }
    }
}
