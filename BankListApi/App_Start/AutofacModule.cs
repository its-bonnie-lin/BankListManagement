using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;

namespace BankListApi.App_Start
{
    public class AutofacModule:Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var types = ThisAssembly.GetTypes();
            string sNamespace = ThisAssembly.GetName().Name;
            var nsArray = new List<string>
            {
                $"{sNamespace}.Controllers",
                $"{sNamespace}.Services",
                $"{sNamespace}.Commands",
                $"{sNamespace}.Repositories"
            };

            builder.RegisterTypes(types.Where(x =>
                    x.Namespace != null && nsArray.Exists(ns => x.Namespace.StartsWith(ns))).ToArray())
                .InstancePerLifetimeScope();
        }
    }
}