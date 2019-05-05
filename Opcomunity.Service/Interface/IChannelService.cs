using Opcomunity.Data.Entities;
using Opcomunity.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opcomunity.Service.Interface
{
    public interface IChannelService
    {
        List<TB_Channel> GetChannelList(int pageIndex, int pageSize, string channel);
        TB_Channel GetChannelById(int id);
        bool EditChannel(int id, string description, bool isAvailable);
        List<TB_AdmUserChannel> GetAdmUserChannel(int userId);
        bool SaveAdmUserChannel(int userId, int channel, int deduction);
        List<ChannelUserModel> GetChannelUserStatistics(DateTime beginDate, DateTime endDate, int admUserId, string channel);
        List<int> GetAdmUserChannelList(int admUserId);
    }
}
