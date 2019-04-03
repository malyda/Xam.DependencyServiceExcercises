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
            //if there are contructors
            if (ctrs.Length >= 1)
            {
                var ctrParams = ctrs[0].GetParameters();
                // if first constructor has parameters
                if (ctrParams.Length > 0)
                {
                    var prms = instanceParameters(ctrParams).ToArray();
                    return Activator.CreateInstance(objectToCreate, prms);
                }
                
                // otherwise create instance with default constructor and bb
                else return Activator.CreateInstance(objectToCreate);
            }
            else return Activator.CreateInstance(objectToCreate);
        }

        private List<object> instanceParameters(ParameterInfo[] ctrParams)
        {
            List<object> parametersToPass = new List<object>();
            foreach (var param in ctrParams)
            {
                var paramType = param.ParameterType;
                
                if (paramType is object)
                {
                    if (CustomDependencyServiceExtended.container.ContainsKey(paramType))
                    { 
                        parametersToPass.Add(CustomDependencyServiceExtended.Resolve(paramType));
                    }
                }  
            }
            return parametersToPass;
        }
    }
}
