using Opcomunity.Service.Models;
using Opcomunity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opcomunity.Service.Interface
{
    public interface ICashOutService
    { 
        List<CashOutTransactionModel> GetList(int pageIndex, int pageSize, string condition, string status);
        CashOutTransactionModel GetDetail(string id);
        bool UpdateStatus(string transactionId, CashStatusConfig cashStatus);
    }
}
