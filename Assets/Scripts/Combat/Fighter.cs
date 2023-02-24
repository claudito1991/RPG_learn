
using UnityEngine;
using System.Collections;
using RPG.Movement;
using RPG.Core;
using System;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float weaponRange = 2f;
        [SerializeField] float timeBetweenAttacks=1f; 

        float timeSinceLastAttack;
        private Health target;
        private float weaponDamage = 5f;

        void Update()
        {
            timeSinceLastAttack +=Time.deltaTime;
            if(target ==null) return;
            if(target.IsDead()) return;
            
            if (!GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(target.transform.position);
            }
            else
            {
                GetComponent<Mover>().Cancel();
                AttackBehaviour();
                
            }
        }

        private void AttackBehaviour()
        {
            transform.LookAt(target.transform.position);
            if(timeSinceLastAttack>= timeBetweenAttacks)
            {
               //This will trigger the Hit() event
                GetComponent<Animator>().SetTrigger("attack");
                timeSinceLastAttack=0f;


            }

        }

        public bool CanAttack(CombatTarget combatTarget)
        {
            if(combatTarget == null) return false;
            Health targetToTest = combatTarget.GetComponent<Health>();
            return targetToTest != null && !targetToTest.IsDead();
        }
         //Attack hit event driven by animation
        private void Hit()
        {
            target.TakeDamage(weaponDamage);
        }



        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.transform.position) < weaponRange;
        }

        public void Attack(CombatTarget target)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            this.target = target.GetComponent<Health>();
        }

        public void Cancel()
        {
            GetComponent<Animator>().SetTrigger("stopAttack");
            target = null;
        }


    }
}
