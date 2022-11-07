using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using Archero.Entity;

namespace Archero.AI
{


    public class AI : MonoBehaviour //MonoBehaviour
    {
        private Movement movement;
        private Attack attack;
        public Rotation rotation;
        private Animation _animation;
        public User user;
        protected Vector3 startPosition;
        private Entity.Entity entity;

        void Start()
        {
            this.movement = new Movement(this);
            this.attack = new Attack(this);
            this.rotation = new Rotation(this);
            this._animation = new Animation(this);
            this.entity = this.gameObject.GetComponent<Entity.Entity>();
            this.startPosition = this.transform.position;
        }

        void Update()
        {
            //this.movement.Update();
            this.attack.Update();
            this.rotation.Update();
            this._animation.Update();
        }


        public void OnCollisionEnter(Collision collision)
        {

            this.movement.handleCollision(collision);
            //Ouput the Collision to the console
            // Debug.Log("Collision : " + collision.gameObject.name);
        }

        //Detect when there is are ongoing Collisions
        public void OnCollisionStay(Collision collision)
        {
            this.movement.handleCollision(collision);
            // OnCollisionEnter(collision);
            //Output the Collision to the console
            //  Debug.Log("Stay : " + collision.gameObject.name);
        }
    }

}