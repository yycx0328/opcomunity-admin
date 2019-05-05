using Opcomunity.Data.Entities;
using Opcomunity.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opcomunity.Service.Interface
{
    public interface IStatisticsService
    {
        List<TB_StatisticsCharge> GetChargeStatistics(DateTime beginDate, DateTime endDate);
        List<TB_StatisticsCallTimes> GetCallTimesStatistics(DateTime beginDate, DateTime endDate);
        List<TB_StatisticsCash> GetCashStatistics(DateTime beginDate, DateTime endDate);
        List<TB_StatisticsNeteaseCall> GetNeteaseCallStatistics(DateTime beginDate, DateTime endDate);
        List<TB_StatisticsCoin> GetCoinStatistics(DateTime beginDate, DateTime endDate);
    }
}
