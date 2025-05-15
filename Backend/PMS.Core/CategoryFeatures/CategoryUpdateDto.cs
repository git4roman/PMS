using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Core.CategoryFeatures
{
    public class CategoryUpdateDto:CategoryCreateDto
    {
        public CategoryUpdateDto(int id)
        {
            Id = id;            
        }

        public int Id { get; set; }        
    }
}
