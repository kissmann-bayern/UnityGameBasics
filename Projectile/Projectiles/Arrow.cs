using UnityEngine;

namespace Archero.Projectile.Projectiles
{
    public class Arrow : Projectile
    {
        void Update() {
          transform.Translate(Vector3.forward * this.speed * Time.deltaTime);
           
           rotateToPosition(this.entity.transform.position);
            Debug.Log("Arrow update");
        }

        public void rotateToPosition(Vector3 targetsPosition) {
            Vector3 observersPosition = transform.position;

            var observer = this;

            var subtraction = targetsPosition - observersPosition;
            var direction = (targetsPosition - observersPosition).normalized;
            var lookRotation = Quaternion.FromToRotation(observer.transform.forward, direction);

            observer.transform.rotation *= lookRotation;
        }
    }
}