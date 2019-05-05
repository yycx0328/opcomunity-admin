using Infrastructure;
using Opcomunity.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackStage.Web
{
    public class IocConfig
    {
        public static void RegisterIoc()
        {
            Ioc.RegisterInheritedTypes(typeof(ServiceBase).Assembly, typeof(ServiceBase));
            Ioc.Register<ILogger, FileLogger>();
        }
    }
}