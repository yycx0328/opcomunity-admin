using Opcomunity.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opcomunity.Service.Interface
{
    public interface IGiftService
    {
        List<GiftTransactionModel> GetTrasactionList(int pageIndex, int pageSize, string condition);
    }
}
