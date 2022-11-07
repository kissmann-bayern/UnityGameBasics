using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
namespace Archero.AI
{
    public class Rotation
    {
        private AI ai;

        private float RotationSpeed = 10f;

        private Quaternion _lookRotation;
        private Vector3 _direction;

        private Transform target
        {
            get { return this.ai.transform; }
        }

        public void rotateToPosition(Vector3 targetsPosition) {
            Vector3 observersPosition = this.ai.transform.position;

            var observer = this.ai;

            var subtraction = targetsPosition - observersPosition;
            var direction = (targetsPosition - observersPosition).normalized;
            var lookRotation = Quaternion.FromToRotation(observer.transform.forward, direction);

            observer.transform.rotation *= lookRotation;
/*
            Rigidbody rigidbody = this.ai.GetComponent<Rigidbody>();
        
             Quaternion targetRotation = rigidbody.rotation * Quaternion.Euler(0, targetRigibody.position.y,0);

            rigidbody.MoveRotation(targetRotation);*/
            /*
                        Rigidbody userRigibody = this.ai.user.GetComponent<Rigidbody>();

            

             Vector3 targetPosition = 
             Quaternion targetRotation = XYZW * Quaternion.Euler(this.ai.transform.position.x,this.ai.transform.position.y,this.ai.transform.position.z)
            Rigidbody rigidbody = 
            rigidbody.MoveRotation()
            */
          
          //  this.ai.transform.rotation = Quaternion.Slerp (this.ai.transform.rotation, Quaternion.LookRotation (movementDirection), Time.deltaTime * 40f);
        }

        private void rotateToUser()
        {
            //find the vector pointing from our position to the target
            _direction = (this.target.position - this.ai.transform.position).normalized;

            //create the rotation we need to be in to look at the target
            _lookRotation = Quaternion.LookRotation(_direction);
            _lookRotation.x = 0;
            _lookRotation.z = 0;

            //rotate us over time according to speed until we are in the required rotation
            Quaternion q = Quaternion.Slerp(this.ai.transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
            q.x = 0;
            q.z = 0;
            
            this.ai.transform.rotation = q;
        }

        public Rotation(AI ai)
        {
            this.ai = ai;
        }

        public void Update()
        {

 //           Quaternion rotate = Quaternion.LookRotation(this.ai.user.transform.position);
   //         this.ai.transform.Rotate((Vector3)new Vector3(0, rotate.y, 0));
    //this.rotateToUser();
        }
    }


}