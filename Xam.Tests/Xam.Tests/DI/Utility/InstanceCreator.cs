using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Xam.Tests.DI.Utility
{
    class InstanceCreator
    {
        public object CreateInstance(Func<object> factory)
        {
            return factory();
        }

        public object CreateInstance(Type objectToCreate)
        {
            var ctrs = objectToCreate.GetConstructors();
            if (ctrs.Length >= 1 && ctrs[0].GetParameters().Length > 0)
            {
                var x = ctrs[0].GetParameters();
                var prms = getParameters(ctrs[0]).ToArray();
                return Activator.CreateInstance(objectToCreate, prms);
            }
            else return Activator.CreateInstance(objectToCreate);
        }
        private List<object> getParameters(ConstructorInfo ctr)
        {
            List<object> parametersToPass = new List<object>();
            foreach (var param in ctr.GetParameters())
            {
                Type paramType2 = param.ParameterType;

                var paramType3 = param.ParameterType.GetType();
                if (paramType2 is object)
                {
                    if (CustomDependencyServiceExtended.container.ContainsKey(paramType2))
                    { 
                        parametersToPass.Add(CustomDependencyServiceExtended.Resolve(paramType2));
                    }
                }
               
            }
            return parametersToPass;
        }

    }
}
