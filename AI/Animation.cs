using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Archero.AI
{
    public class Animation
    {
        private AI ai;
        private UnityEngine.Animator animation;

        public Animation(AI ai)
        {
            this.ai = ai;
            this.animation = this.ai.gameObject.GetComponent<UnityEngine.Animator>();
        }

        private void forward()
        {
            this.animation.Play("walk");
        }

        private void back()
        {
            this.animation.Play("walk");
        }

        private void left()
        {
            this.animation.Play("walk");
        }

        private void right()
        {
            this.animation.Play("walk");
        }

        public void Update()
        {
            this.forward();
        }
    }


}