using System;
using Infrastructure;
using Opcomunity.Data.Entities;
using log4net;
using System.Reflection;
using BackStage.Core.Log;

namespace Opcomunity.Service
{
    public interface IServiceBase
    {
    }

    public abstract class ServiceBase
    {
        protected static ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.Name);

        protected OpcomunityContext NewContext()
        {
            return new OpcomunityContext();
        }

        protected void Try(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                Logger.Log("异常",ex);
            }
        }
    }
}
