using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace Archero.Projectile
{
    public abstract class Projectile : MonoBehaviour {
        public float speed;
        public float launchVelocity = 700f;
        public Entity.Entity entity;
        
        void Update() {
            //new Vector3(this.entity.transform.rotation.x,this.entity.transform.rotation.y,this.entity.transform.rotation.z));
            transform.Translate(Vector3.forward * this.speed * Time.deltaTime);
        }


    }

}