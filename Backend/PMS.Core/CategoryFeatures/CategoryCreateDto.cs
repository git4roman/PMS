using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Core.CategoryFeatures
{
    public class CategoryCreateDto
    {
        //public CategoryCreateDto( string name)
        //{
        //    Name = name;
        //}
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }        
    }
}
