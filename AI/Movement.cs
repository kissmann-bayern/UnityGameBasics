using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using Archero.Entity.Translation;
namespace Archero
{
    namespace AI
    {

public class AggresiveMovement
        {
            private AI ai;
            public AggresiveMovement(AI ai)
            {
                this.ai = ai;
            }
            private Vector3? startVector { get; set; }

            private string[] directonList = {
                "n", "no", "o", "os", "s", "sw", "w", "wn"
            };

            private int currentDirecton = 0;
            public float directionDistance = (float)5f;
            public float speed = 1f;
            public void Update()
            {
                this.ai.rotation.rotateToPosition(this.ai.user.GetComponent<Rigidbody>().position);

                //this.ai.rotation.rotateToPosition(this.ai.GetComponent<Rigidbody>().position + vector);
                ai.transform.Translate((Vector3.forward * this.speed) * Time.deltaTime);
                /*
                if (this.directonList.Length < this.currentDirecton + 1)
                    this.currentDirecton = 0;

                if (this.startVector == null)
                {
                    this.startVector = ai.transform.position;
                }

                Vector3 _startVector = (Vector3)this.startVector;
                float distance = Vector3.Distance(ai.transform.position, _startVector);

                if (distance >= this.directionDistance)
                {
                    //this.currentDirecton++;
                    System.Random rand = new System.Random();
                    this.currentDirecton = rand.Next(0, this.directonList.Length - 1);
                    this.startVector = null;
                    return;
                }

                Vector3[] moves = this.TransformVectorAI(this.directonList[this.currentDirecton].ToUpper()).ToArray();

                foreach (Vector3 move in moves)
                {
                    this.move(Archero.Entity.Translation.Math.TransformVector(move, Time.deltaTime, this.speed));
                }
*/

            }

/*
AI Movement Code
{
    ""
}


*/

            private List<Vector3> TransformVectorAI(string direction)
            {
                List<Vector3> vectors = new List<Vector3>();

                /*
                N = Norden
                O = Osten
                S = Süden
                W = Westen
                */
                if (direction.Contains("N"))
                {
                    vectors.Add(Vector3.forward);
                }

                if (direction.Contains("O"))
                {
                    vectors.Add(Vector3.right);
                }

                if (direction.Contains("S"))
                {
                    vectors.Add(Vector3.back);
                }

                if (direction.Contains("W"))
                {
                    vectors.Add(Vector3.left);
                }

                return vectors;
            }


            public void move(Vector3 vector, bool ignoreCollider = false)
            {
                
            }

            public void handleCollision(Collision collision)
            {
        
            }



        }
    
        public class Movement
        {
            private AI ai;
            public Movement(AI ai)
            {
                this.ai = ai;
            }
            private Vector3? startVector { get; set; }

            private string[] directonList = {
                "n", "no", "o", "os", "s", "sw", "w", "wn"
            };

            private int currentDirecton = 0;
            public float directionDistance = (float)5f;
            public float speed = 1f;
            public void Update()
            {

                if (this.directonList.Length < this.currentDirecton + 1)
                    this.currentDirecton = 0;

                if (this.startVector == null)
                {
                    this.startVector = ai.transform.position;
                }

                Vector3 _startVector = (Vector3)this.startVector;
                float distance = Vector3.Distance(ai.transform.position, _startVector);

                if (distance >= this.directionDistance)
                {
                    //this.currentDirecton++;
                    System.Random rand = new System.Random();
                    this.currentDirecton = rand.Next(0, this.directonList.Length - 1);
                    this.startVector = null;
                    return;
                }

                Vector3[] moves = this.TransformVectorAI(this.directonList[this.currentDirecton].ToUpper()).ToArray();

                foreach (Vector3 move in moves)
                {
                    this.move(Archero.Entity.Translation.Math.TransformVector(move, Time.deltaTime, this.speed));
                }


            }

/*
AI Movement Code
{
    ""
}


*/

            private List<Vector3> TransformVectorAI(string direction)
            {
                List<Vector3> vectors = new List<Vector3>();

                /*
                N = Norden
                O = Osten
                S = Süden
                W = Westen
                */
                if (direction.Contains("N"))
                {
                    vectors.Add(Vector3.forward);
                }

                if (direction.Contains("O"))
                {
                    vectors.Add(Vector3.right);
                }

                if (direction.Contains("S"))
                {
                    vectors.Add(Vector3.back);
                }

                if (direction.Contains("W"))
                {
                    vectors.Add(Vector3.left);
                }

                return vectors;
            }


            public void move(Vector3 vector, bool ignoreCollider = false)
            {
                this.ai.rotation.rotateToPosition(this.ai.user.GetComponent<Rigidbody>().position);

                //this.ai.rotation.rotateToPosition(this.ai.GetComponent<Rigidbody>().position + vector);
                ai.transform.Translate(vector);
            }

            public void handleCollision(Collision collision)
            {
                if (collision.collider.gameObject.name.StartsWith("wall"))
                {
                    System.Random rand = new System.Random();
                    this.currentDirecton = rand.Next(0, this.directonList.Length - 1);
                }
            }



        }
    }
}