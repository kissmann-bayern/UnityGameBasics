using System;
using UnityEngine;
using Archero.Event;
using System.Collections;
using System.Collections.Generic;

namespace Archero
{
    namespace Event
    {
        [System.AttributeUsage(System.AttributeTargets.Method)
]
        public class EventHandler : System.Attribute
        {
            public System.Type ev;
            public object[] attr;
            public EventHandler(System.Type ev, params object[] attr)
            {
                this.ev = ev;
                this.attr = attr;
            }


        }

    }


}