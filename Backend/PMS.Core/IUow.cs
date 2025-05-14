using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Core.CategoryFeatures;

namespace PMS.Core
{
    public interface IUow
    {
        ICategoryRepo Category { get; }
        void Save();

    }
}
