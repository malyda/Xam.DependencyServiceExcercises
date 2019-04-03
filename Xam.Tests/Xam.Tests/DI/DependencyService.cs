using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xam.Tests.VM;
using Xamarin.Forms;

namespace Xam.Tests.DI
{
    public class CustomDependencyService
    {
        static Dictionary<Type, Type> serviceContainer = new Dictionary<Type, Type>();
        static Dictionary<Type, Type> vmContainer = new Dictionary<Type, Type>();

        public static void Register<TAService, TService>() where TAService : class where TService : class
        {
            serviceContainer.Add(typeof(TAService), typeof(TService));
        }

       

        public static TAService Resolve<TAService>() where TAService: class
        {
            var typeFromCont = serviceContainer[typeof(TAService)]; 

            return Activator.CreateInstance(typeFromCont) as TAService;
        }

        public static void RegisterPageVM<ContentPage, VMBase>()
        {
            vmContainer.Add(typeof(ContentPage), typeof(VMBase));
        }

        public static VMbase ResolvePageVM<ContentPage>()
        {
            var typeFromCont = vmContainer[typeof(ContentPage)];
            
            return Activator.CreateInstance(typeFromCont) as VMbase;
        } 
    }
}
