using Opcomunity.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opcomunity.Service.Interface
{
    public interface IUserService
    { 
        List<UserModel> GetUserList(int pageIndex, int pageSize, string condition, string channel);

        List<UserCoinModel> GetUserCoinList(int pageIndex, int pageSize, string condition);

        List<UserCoinJournalModel> GetUserCoinJournalList(long userId,int pageIndex, int pageSize);

        List<UserIncomeJournalModel> GetUserIncomeJournalList(long userId,int pageIndex, int pageSize, string condition);

        List<InviteUserModel> GetBindUserList(long userId, string condition);
           
        InviteUserModel GetBindUserModel(long id);

        bool SaveInviteUser(long id, int cost, int cashout);

        string AddInviteUser(long userId, long newUserId);

        bool SetBlackUser(long userId);
    }
}
