using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Archero.Item;
namespace Archero
{
    namespace Item
    {
        namespace Items
        {
            public class Test : Archero.Item.ItemBase, Archero.Item.Collactable
            {
                public string echo = "aa";

                public override void onCollision()
                {
                    Debug.Log("Collide Item: " + this);
                }

                public void onCollect(ItemBase item)
                {
                    Destroy(item.gameObject);
                }
            }
        }
    }
}