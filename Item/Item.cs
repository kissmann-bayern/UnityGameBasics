using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Archero
{
    namespace Item
    {
        public abstract class ItemBase : MonoBehaviour
        {
            private void Update()
            {

            }

            public abstract void onCollision();
        }

        public interface Collactable
        {
            public void onCollect(ItemBase item);
        }
    }
}