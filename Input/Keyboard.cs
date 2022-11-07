using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Archero
{
    namespace Input
    {
        public class Keyboard : MonoBehaviour
        {
            public List<KeyCode> pressedKeys = new List<KeyCode>();

            public List<KeyCode> watch = new List<KeyCode>();

            public Dictionary<KeyCode, UnityEngine.Vector3> KeyCodeToVectorAction = new Dictionary<KeyCode, UnityEngine.Vector3>()
            {
                { KeyCode.UpArrow, Vector3.forward},
                { KeyCode.DownArrow, Vector3.back},
                { KeyCode.LeftArrow, Vector3.left},
                { KeyCode.RightArrow, Vector3.right},
            };

            void Update()
            {
                pressedKeys.Clear();

                if (UnityEngine.Input.GetKey(KeyCode.UpArrow))
                    this.pressedKeys.Add(KeyCode.UpArrow);

                if (UnityEngine.Input.GetKey(KeyCode.DownArrow))
                    this.pressedKeys.Add(KeyCode.DownArrow);

                if (UnityEngine.Input.GetKey(KeyCode.LeftArrow))
                    this.pressedKeys.Add(KeyCode.LeftArrow);

                if (UnityEngine.Input.GetKey(KeyCode.RightArrow))
                    this.pressedKeys.Add(KeyCode.RightArrow);
            
                foreach (KeyCode keyCode in this.watch) {
                    if (UnityEngine.Input.GetKey(keyCode))
                        this.pressedKeys.Add(keyCode);
                }
            }
        }
    }
}