using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Core.OderFeatures;
using PMS.Core.UserFeatures;

namespace PMS.Core.CustomerFeatures
{
    public class CustomerEntity 
    {
        protected CustomerEntity()
        {
            
        }
        public CustomerEntity(int UserId)
        {
            this.UserId = UserId;
            Guid = Guid.NewGuid();
            CreatedDate= DateOnly.FromDateTime(DateTime.Now);
            CreatedTime= TimeOnly.FromDateTime(DateTime.Now);
        }

        public int Id { get; set; }
        public Guid Guid { get; set; } 
        public DateOnly CreatedDate { get; set; }
        public TimeOnly CreatedTime { get; set; }

        public int UserId { get; set; }           
        public UserEntity User { get; set; }
        
        public int OrderId { get; set; }
        public OrderEntity? Order { get; set; }
    }
}
