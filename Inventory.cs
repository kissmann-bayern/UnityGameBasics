using System;
using System.Linq;
using System.Globalization;
using System.Security.Cryptography;
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
    public class Inventory : MonoBehaviour
    {
        public EventManager eventManager;
        private  EventListener eventListener;
        public static object[] objectList(params object[] arguments)
        {
            return arguments;
        }
        class EventListener : Archero.Event.Listener
        {
           // EventBase keyCodeEvent = new KeyCodeEvent(KeyCode.I);

            [Archero.Event.EventHandler(typeof(KeyCodeEvent), KeyCode.I)]
            public void handle(KeyCodeEvent keyCodeEvent)
            {
                Debug.Log(keyCodeEvent);
                Debug.Log("I");
            }
        }

        public Dictionary<ItemBase, int> items = new Dictionary<ItemBase, int>()
        {
            {new Test(), 20}
        };

        void Start()
        {
            this.eventListener = new EventListener();
            this.eventManager.registerListener(this.eventListener);
        }

        void Update()
        {
            this.eventManager.fireEventByListener(this.eventListener);
        }
    }
}