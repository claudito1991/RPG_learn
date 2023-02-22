
using UnityEngine;
using System.Collections;
using RPG.Movement;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField] float weaponRange = 2f;
        private Transform targetTransform;
        void Update()
        {
            if(targetTransform ==null) return;
            if (!GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(targetTransform.position);

            }
            else
            {
                GetComponent<Mover>().Stop();
            }
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, targetTransform.position) < weaponRange;
        }

        public void Attack(CombatTarget target)
        {
            targetTransform = target.transform;
        }

        public void Cancel()
        {
            targetTransform = null;
        }
    }
}
