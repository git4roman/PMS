using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Core.CategoryFeatures
{
    public class CategoryUpdateDto:CategoryCreateDto
    {
        public CategoryUpdateDto(int id,string name,
                        DateOnly createdDate, DateOnly updatedDate,
                        TimeOnly createdTime, TimeOnly updatedTime): base(name, createdDate, updatedDate, createdTime, updatedTime) 
        {
            Id = id;   
        }

        public int Id { get; set; }        
    }
}
