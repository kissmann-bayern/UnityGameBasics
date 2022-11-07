using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Archero.Entity.Translation;
using Archero.Input;
namespace Archero
{
    namespace Entity
    {
        public abstract class Entity : EntityBase
        {
            public float live = 100f;
            public int level = 0;

            public bool fly = false;

            public float speed = 1;

            public bool isAI = true;

            public Keyboard keyboard;

            public abstract void Start();

            public abstract void Update();

            public void move(Vector3 vector, bool ignoreCollider = false)
            {
                this.gameObject.transform.Translate(vector);
            }

            public void keyboardListener()
            {
                if (this.isAI)
                    return;
                    
                if (this.keyboard)
                {
                    if (this.keyboard.pressedKeys.Count > 0)
                    {
                        foreach (KeyCode key in this.keyboard.pressedKeys)
                        {
                            this.move(Math.TransformVector(this.keyboard.KeyCodeToVectorAction[key], Time.deltaTime, this.speed));
                        }
                    }
                }
            }
        }
    }
}