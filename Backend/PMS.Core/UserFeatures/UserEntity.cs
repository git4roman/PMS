using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Core.ProductFeatures;

namespace PMS.Core.UserFeatures
{
    public class UserEntity
    {
        protected UserEntity()
        {
        }

        public UserEntity(string FirstName, string MiddleName, string LastName, string PasswordHash, string Email, string PhoneNumber, string Address) {
            this.FirstName = FirstName;
            this.MiddleName = MiddleName;
            this.LastName = LastName;
            this.PasswordHash = PasswordHash;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.Address = Address;
            CreatedDate = DateOnly.FromDateTime(DateTime.Now);
            CreatedTime = TimeOnly.FromDateTime(DateTime.Now);
            Status = UserStatusEnum.InActive;
        }

        public UserEntity(int Id,string FirstName, string MiddleName, string LastName, string PasswordHash, string Email, string PhoneNumber, string Address):this(FirstName,MiddleName,LastName,PasswordHash,Email,PhoneNumber,Address)
        {
            this.Id = Id;
        }
        public int Id { get; protected set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash {  get; set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public DateOnly CreatedDate { get; set; }
        public TimeOnly CreatedTime { get; set; }

        public string Status { get; set; }
        public void Activate()
        {
            Status = UserStatusEnum.Active;
        }
        public void Deactivate()
        {
            Status = UserStatusEnum.InActive;
        }
        public bool IsActive()
        {
            return Status == UserStatusEnum.Active;
        }


    }
}
