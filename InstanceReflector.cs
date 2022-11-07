using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Archero.Event;

namespace Archero
{
    public class InstanceReflector
    {

        public static MethodInfo[] getMethodsByAnnotation(Listener instance)
        {
            List<MethodInfo> methods = new List<MethodInfo>();
            MethodInfo[] methodInfos = instance.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance);

            foreach (MethodInfo methodInfo in methodInfos)
            {
               Archero.Event.EventHandler eventHandler = (Archero.Event.EventHandler) methodInfo.GetCustomAttribute<Archero.Event.EventHandler>();
            
                if (eventHandler != null)
                    methods.Add(methodInfo);
            }

            return methods.ToArray();
        }
    }
}