
using System.Collections;
using UnityEngine;
using RPG.Movement;
using RPG.Combat;
using System;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
        {
            
            if(InteractWithCombat()) return;
            if(InteractWithNothing()) return;
            InteractWithMovement();

        }

        private bool InteractWithNothing()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());

            if(hits.Length == 0)
            {
                Debug.Log("Nothing to interact");
                return true;
            }

            return false;
        }

        private bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>(); 
                if ( target == null) continue;
                
                if(Input.GetMouseButtonDown(0))
                {
                    GetComponent<Fighter>().Attack(target);
                    
                }
                return true;

            }
            return false;

        }

        private void InteractWithMovement()
        {
    
            if (Input.GetMouseButton(0))
            {
                MoveToCursor();
            }
        }

        private void MoveToCursor()
        {
            Ray ray = GetMouseRay();
            RaycastHit hit;
            bool hasHit = Physics.Raycast(ray, out hit);

            if (hasHit)
            {
                GetComponent<Mover>().StartMoveAction(hit.point);
                
            }

        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}

