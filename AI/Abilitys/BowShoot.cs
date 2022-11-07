using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using Archero.Projectile;

namespace Archero.AI.Abilitys
{
    public class BowShoot : Ability
    {
        public GameObject projectile;
        public GameObject startpoint;
        public BowShoot()
        {

        }

        public override void trigger()
        {
  
            GameObject projectile = Instantiate(this.projectile, new Vector3(this.startpoint.transform.position.x, this.startpoint.transform.position.y +2, this.startpoint.transform.position.z), transform.rotation);
         //   projectile.GetComponent<Rigidbody>().AddRelativeForce(new Vector3
                                              //  (0, projectile.GetComponent<Projectile.Projectile>().launchVelocity, 0));
        }

    }
}
