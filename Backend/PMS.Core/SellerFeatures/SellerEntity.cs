using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Core.UserFeatures;

namespace PMS.Core.SellerFeatures
{
    public class SellerEntity
    {
        public SellerEntity(int UserId)
        {
            Guid= Guid.NewGuid();
            this.UserId = UserId;
            CreatedDate = DateOnly.FromDateTime(DateTime.Now);
            CreatedTime = TimeOnly.FromDateTime(DateTime.Now);
            Status = SellerStatusEnum.UnVerified;
        }

        public int Id { get; set; }
        public Guid Guid { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        public DateOnly CreatedDate { get; set; }
        public TimeOnly CreatedTime { get; set; }
        public string Status { get; set; }


        public void Verified()
        {
            Status = SellerStatusEnum.Verified;
        }
        public void Deactivate()
        {
            Status = SellerStatusEnum.UnVerified;
        }
        public bool IsVerified()
        {
            return Status == SellerStatusEnum.Verified;
        }
    }
}
