using Opcomunity.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opcomunity.Service.Interface
{
    public interface ILiveCallService
    {
        List<CallAnchorModel> GetUnConnectList(int pageIndex, int pageSize, string condition);
        List<NeteaseCallModel> GetConnectList(int pageIndex, int pageSize, string condition);
        List<NeteaseTextModel> GetTextList(int pageIndex, int pageSize, string f_condition, string t_condition);
    }
}
