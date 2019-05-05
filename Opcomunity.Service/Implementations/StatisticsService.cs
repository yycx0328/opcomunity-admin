using Opcomunity.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opcomunity.Data.Entities;
using Opcomunity.Service.Models;
using System.Data.Entity.SqlServer;

namespace Opcomunity.Service.Implementations
{
    public class StatisticsService : ServiceBase, IStatisticsService
    {
        public List<TB_StatisticsCharge> GetChargeStatistics(DateTime beginDate, DateTime endDate)
        {
            using (var context = base.NewContext())
            {
                var query = from s in context.TB_StatisticsCharge
                            where s.Date >= beginDate && s.Date <= endDate
                            select s;
                return query.ToList();
            }
        }

        public List<TB_StatisticsCallTimes> GetCallTimesStatistics(DateTime beginDate, DateTime endDate)
        {
            using (var context = base.NewContext())
            {
                var query = from s in context.TB_StatisticsCallTimes
                            where s.Date >= beginDate && s.Date <= endDate
                            select s;
                return query.ToList();
            }
        }

        public List<TB_StatisticsCash> GetCashStatistics(DateTime beginDate, DateTime endDate)
        {
            using (var context = base.NewContext())
            {
                var query = from s in context.TB_StatisticsCash
                            where s.Date >= beginDate && s.Date <= endDate
                            select s;
                return query.ToList();
            }
        }

        public List<TB_StatisticsCoin> GetCoinStatistics(DateTime beginDate, DateTime endDate)
        {
            using (var context = base.NewContext())
            {
                var query = from s in context.TB_StatisticsCoin
                            where s.Date >= beginDate && s.Date <= endDate
                            select s;
                return query.ToList();
            }
        }

        public List<TB_StatisticsNeteaseCall> GetNeteaseCallStatistics(DateTime beginDate, DateTime endDate)
        {
            using (var context = base.NewContext())
            {
                var query = from s in context.TB_StatisticsNeteaseCall
                            where s.Date >= beginDate && s.Date <= endDate
                            select s;
                return query.ToList();
            }
        }
    }
}
