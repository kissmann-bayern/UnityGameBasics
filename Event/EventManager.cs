using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Archero.Input;
using Archero.Event.Events;

namespace Archero
{
    namespace Event
    {
        public class EventManager : MonoBehaviour
        {
            public Keyboard keyboard;

            private List<Listener> listeners = new List<Listener>();

            public void fireEventByListener(Listener listener)
            {
                MethodInfo[] methodInfos = Archero.InstanceReflector.getMethodsByAnnotation(listener);
            }

            public void registerListener(Listener listener)
            {
                this.listeners.Add(listener);

                //init
                EventBase[] events = this.filterEventsFromListener(listener).ToArray();

                foreach (EventBase eventBase in events) {
                    eventBase.keyboard = this.keyboard;
                    eventBase.init();
                }
            }

            public List<EventBase> filterEventsFromListener(Listener listener)
            {
                List<EventBase> events = new List<EventBase>();

                MethodInfo[] methodInfos = Archero.InstanceReflector.getMethodsByAnnotation(listener);

                Type eventBaseType = typeof(Archero.Event.Event);

                foreach (MethodInfo methodInfo in methodInfos)
                {
                    Archero.Event.EventHandler eventHandler = methodInfo.GetCustomAttribute<Archero.Event.EventHandler>();

                    if (methodInfo.GetParameters().Length != 1)
                        return events;

                    if (!methodInfo.GetParameters()[0].ParameterType.BaseType.Equals(typeof(EventBase)))
                        return events;


                    EventBase eventBase = (EventBase)Activator.CreateInstance(eventHandler.ev, eventHandler.attr);
                    events.Add(eventBase);
                }

                return events;
            }

            private void invokeMethods(MethodInfo[] methodInfos)
            {
                foreach (MethodInfo methodInfo in methodInfos)
                {
                    Archero.Event.EventHandler eventHandler = methodInfo.GetCustomAttribute<Archero.Event.EventHandler>();
                    EventBase instance = (EventBase)Activator.CreateInstance(eventHandler.ev, eventHandler.attr);

                    instance.keyboard = this.keyboard;

                    methodInfo.Invoke(null, new object[] { instance });
                }
            }

            private List<MethodInfo> filterMethodsFromListenersByEvent(Type eventBase)
            {
                List<MethodInfo> methods = new List<MethodInfo>();
                foreach (Listener listener in this.listeners)
                {
                    MethodInfo[] methodInfos = Archero.InstanceReflector.getMethodsByAnnotation(listener);

                    foreach (MethodInfo methodInfo in methodInfos)
                    {
                        if (methodInfo.GetParameters().Length != 1)
                            return methods;

                        if (!methodInfo.GetParameters()[0].GetType().IsInstanceOfType(eventBase))
                            return methods;

                        methods.Add(methodInfo);
                    }
                }

                return methods;
            }

            public void fireEvent(Type eventBase)
            {
                List<MethodInfo> methods = this.filterMethodsFromListenersByEvent(eventBase);
                invokeMethods(methods.ToArray());
            }

            void Update()
            {
                if (this.keyboard.pressedKeys.Count > 0)
                {
                    this.fireEvent(typeof(KeyCodeEvent));
                }
            }
        }
    }
}