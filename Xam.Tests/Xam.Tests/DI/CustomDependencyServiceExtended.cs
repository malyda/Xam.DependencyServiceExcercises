using System;
using System.Collections.Generic;
using Xam.Tests.DI.Utility;

namespace Xam.Tests.DI
{
    class CustomDependencyServiceExtended
    {
        public static Dictionary<Type, Tuple<Type, Func<object>>> container = new Dictionary<Type, Tuple<Type, Func<object>>>();
        static InstanceCreator instanceCreator = new InstanceCreator();
        public static void RegisterFactory<Typee, TAService>(Func<object> factory = null) where TAService : class
        {
            container.Add(typeof(Typee), new Tuple<Type, Func<object>>(typeof(TAService), factory));
        }

        public static object Resolve<TAService>() where TAService : class
        {
            var tupleFromContainer = container[typeof(TAService)];
            return createInstance(tupleFromContainer);
        }

        public static object Resolve(Type type)
        {
            var tupleFromContainer = container[type];
            return createInstance(tupleFromContainer);

        }

        private static object createInstance(Tuple<Type, Func<object>> tuple)
        {
            var factory = tuple.Item2;

            if (factory == null)
            {
                return instanceCreator.CreateInstance(tuple.Item1);
            }
            else
            {
                return instanceCreator.CreateInstance(factory);
            }
        }
    }
}
