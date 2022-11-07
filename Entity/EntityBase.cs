using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
namespace Archero.Entity
{

    public abstract class EntityBase : MonoBehaviour, CollisionDedection {
        
        public void OnCollisionEnter(Collision collision) {
            this.OnCollision(collision);
        }
    

        public void OnCollisionStay(Collision collision) {
            this.OnCollision(collision);
        }

        public abstract void OnCollision(Collision collision);
        
    }
}