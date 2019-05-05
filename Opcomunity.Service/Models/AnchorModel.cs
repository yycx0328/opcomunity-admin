using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opcomunity.Service.Models
{
    public class AnchorModel
    {
        public long UserId { get; set; }
        public string NickName { get; set; }
        public string PhoneNo { get; set; }
        public string Avatar { get; set; }
        public string ThumbnailAvatar { get; set; }
        public string Description { get; set; }
        public long Glamour { get; set; }
        public int CashRatio { get; set; }
        public int CallRatio { get; set; }
        public System.DateTime ApplyTime { get; set; }
        public bool IsAuth { get; set; }
        public Nullable<System.DateTime> AuthTime { get; set; }
        public bool IsBlack { get; set; }
        public string IdentityPositive { get; set; }
        public virtual IQueryable<UserPhotoItem> UserPhotoItems { get; set; }

    }
}
