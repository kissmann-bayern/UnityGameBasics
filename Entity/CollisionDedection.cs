using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace Archero.Entity
{
    public interface CollisionDedection
    {
        void OnCollisionEnter(Collision collision);

        void OnCollisionStay(Collision collision);
    }
}