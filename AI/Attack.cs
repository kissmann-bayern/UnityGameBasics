
using System.Collections;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Archero.AI.Abilitys;

namespace Archero.AI
{
    public class Action
    {
        public int? timeout { get; set; }
        public System.Type triggerAbility;

        public static Action get(int? timeout, System.Type triggerAbility)
        {
            Action action = new Action();
            action.timeout = timeout;
            action.triggerAbility = triggerAbility;
            return action;
        }
    }

    public class Attack
    {
        private AI ai;

        private List<Action> attackTemplate = new List<Action>();

        private int lastAttackTemplate = 0;

        private bool timeout = false;

        public Attack(AI ai)
        {
            this.ai = ai;

            this.attackTemplate.Add(Action.get(null, typeof(BowShoot)));
            this.attackTemplate.Add(Action.get(10, null));
        }

        public void Update()
        {
            if (this.attackTemplate.Count <= this.lastAttackTemplate)
            {
                this.lastAttackTemplate = 0;
            }

            if (this.timeout)
                return;

            if (this.attackTemplate[this.lastAttackTemplate].timeout != null)
            {

                this.timeout = true;

                System.Action afterAction = () =>
                {
                    this.lastAttackTemplate++;
                    this.timeout = false;
                };

                Thread runThread = new Thread(new ThreadStart(() => {
                    Thread.Sleep((int)this.attackTemplate[this.lastAttackTemplate].timeout * 1000);
                    afterAction();
                }));
            /*    System.Action run = async () =>
                {

                };*/


                runThread.Start();

                /* this.TimeoutAfter(new Task(() =>
                 {

                 }), (int)this.attackTemplate[this.lastAttackTemplate].timeout * 60);*/
                /*Task.Run(() => this.TimeoutAfter(new Task(() =>
                {
                   
                }), (int)10));*/

                //  this.Timeout((int)this.attackTemplate[this.lastAttackTemplate].timeout).Start();
                //Task.Run(() => this.Timeout((int) this.attackTemplate[this.lastAttackTemplate].timeout));

            }
            else if (this.attackTemplate[this.lastAttackTemplate].triggerAbility != null)
            {
                Ability ability = (Ability)this.ai.GetComponent(this.attackTemplate[this.lastAttackTemplate].triggerAbility);
                this.lastAttackTemplate++;
                ability.trigger();

                // this.attackTemplate[this.lastAttackTemplate].triggerAbility.trigger();
            }
        }
    }


}