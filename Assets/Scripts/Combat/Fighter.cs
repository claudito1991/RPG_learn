
using UnityEngine;
using System.Collections;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float weaponRange = 2f;
        [SerializeField] float timeBetweenAttacks=1f; 

        float timeSinceLastAttack;
        private Transform targetTransform;
        void Update()
        {
            timeSinceLastAttack +=Time.deltaTime;
            if(targetTransform ==null) return;
            if (!GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(targetTransform.position);
            }
            else
            {
                GetComponent<Mover>().Cancel();
                AttackBehaviour();
                
            }
        }

        private void AttackBehaviour()
        {
            if(timeSinceLastAttack>= timeBetweenAttacks)
            {
                GetComponent<Animator>().SetTrigger("attack");
                timeSinceLastAttack=0f;
            }

        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, targetTransform.position) < weaponRange;
        }

        public void Attack(CombatTarget target)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            targetTransform = target.transform;
        }

        public void Cancel()
        {
            targetTransform = null;
        }

        private void Hit()
        {
            
        }
    }
}
