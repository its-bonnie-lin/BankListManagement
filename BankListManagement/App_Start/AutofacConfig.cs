using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using System.Web.Mvc;


namespace BankListManagement.App_Start
{
    public static class AutofacConfig
    {
        public static void Register()
        {
            //容器建立者
            var builder = new ContainerBuilder();
            builder.RegisterModule<AutofacModule>();

            //建立容器
            IContainer container = builder.Build();

            //解析容器內的型別
            AutofacDependencyResolver resolver = new AutofacDependencyResolver(container);

            //建立相依解析器
            DependencyResolver.SetResolver(resolver);

        }
    }
}