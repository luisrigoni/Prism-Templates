﻿using System;
#if (AutofacContainer)
using Autofac;
using Prism.Autofac;
#endif
#if (DryIocContainer)
using DryIoc;
using Prism.DryIoc;
#endif
#if (NinjectContainer)
using Ninject;
using Prism.Ninject;
#endif
#if (UnityContainer)
using Microsoft.Practices.Unity;
using Prism.Unity;
#endif
#if (AADAuth || AADB2CAuth)
using Microsoft.Identity.Client;
#endif

namespace Company.MobileApp.iOS
{
    public class iOSInitializer : IPlatformInitializer
    {
#if (AutofacContainer)
        public void RegisterTypes(ContainerBuilder builder)
#elseif (DryIocContainer)
        public void RegisterTypes(IContainer container)
#elseif (NinjectContainer)
        public void RegisterTypes(IKernel kernel)
#elseif (UnityContainer)
        public void RegisterTypes(IUnityContainer container)
#endif
        {
            // Register Any Platform Specific Implementations that you cannot 
            // access from Shared Code
#if (AADAuth || AADB2CAuth) 
  #if (AutofacContainer)
            builder.RegisterInstance(new UIParent()).As<UIParent>().SingleInstance();
  #elseif (DryIocContainer)
            container.UseInstance(new UIParent());
  #elseif (NinjectContainer)
            kernel.Bind<UIParent>().ToConstant(new UIParent()).InSingletonScope();
  #elseif (UnityContainer)
            container.RegisterInstance(new UIParent());
  #endif
#endif
        }
    }
}
