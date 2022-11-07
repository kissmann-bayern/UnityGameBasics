using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Archero.Item;
using Archero.Item.Items;
using Archero.Input;
using Archero.Event;
using Archero.Event.Events;

namespace Archero
{
    namespace Event
    {
        namespace Events
        {
            public class KeyCodeEvent : Archero.Event.EventBase
            {
                private KeyCode keyCode;
                public KeyCodeEvent(KeyCode keyCode) {
                    this.keyCode = keyCode;
                }

                public override bool runEvent()
                {
                    return this.keyboard.pressedKeys.Contains(this.keyCode);
                }

                public override void init()
                {
                    this.keyboard.watch.Add(this.keyCode);
                }
            }
        }
    }
}