using Opcomunity.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opcomunity.Service.Interface
{
    public interface IChargeService
    {
        List<ChargeOrderModel> GetList(int pageIndex, int pageSize, string condition, string status);
    }
}
