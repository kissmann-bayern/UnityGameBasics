using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Archero.Input;
using Archero.Item;


namespace Archero
{
    namespace Entity
    {
        namespace Translation
        {
            public abstract class TranslationController : MonoBehaviour
            {

                public abstract void OnGameObjectCollision(GameObject collisionGameObject);
                public abstract void Update();
                public abstract void move(Vector3 vector, bool ignoreCollider = false);

                private void handleCollision(Collision collision)
                {
                    GameObject go = collision.gameObject;
                    if (!go)
                        return;

                    OnGameObjectCollision(go);

                    if (go.GetComponent<ItemBase>() == null)
                    {
                        return;
                    }

                    ItemBase item = go.GetComponent<ItemBase>();


                    if (!item)
                        return;

                    item.onCollision();
                   

                    if (item is Collactable)
                    {
                        Debug.Log("Item: " + item);

                        Collactable collactableItem = go.GetComponent<Collactable>();
                        collactableItem.onCollect(item);
                    }
                }

                //Detect when there is a collision starting
                void OnCollisionEnter(Collision collision)
                {

                    this.handleCollision(collision);
                    //Ouput the Collision to the console
                    // Debug.Log("Collision : " + collision.gameObject.name);
                }

                //Detect when there is are ongoing Collisions
                void OnCollisionStay(Collision collision)
                {
                    this.handleCollision(collision);
                    // OnCollisionEnter(collision);
                    //Output the Collision to the console
                    //  Debug.Log("Stay : " + collision.gameObject.name);
                }



            }

            public class Math
            {
                public static Vector3 TransformVector(Vector3 vector, float deltaTime, float speed)
                {
                    return (vector * deltaTime) * speed;
                }

             }
        }
    }
}