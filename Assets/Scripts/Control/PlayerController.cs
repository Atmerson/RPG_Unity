using System;
using RPG.Combat;
using RPG.Movement;
using UnityEngine;


namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        Mover _mover;

        //controls player action/movement
        private void Start()
        {
            _mover = GetComponent<Mover>();
        }

        private void Update() //remember it runs every fram
        {
            if (IntereactWithCombat()) return;

            if (IntereactWithMovement()) return;
            
        }

        private bool IntereactWithCombat()
        {
            
            //find a target then attack
            
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
                CombatTarget target = hit.collider.GetComponent<CombatTarget>();
                if (target == null) continue;

                if (Input.GetMouseButtonDown(0))
                {
                    GetComponent<Fighter>().Attack(target);
                    
                }
                
                return true; //hovering over enemy, recognized.

            }

            return false;

        }

        private bool IntereactWithMovement()
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit); //fire ray


            //move player to where mouse pointed to
            if (hasHit)
            {
                if (Input.GetMouseButton(0))
                {
                    _mover.MoveTo(hit.point);
                }
                
                return true; //GetComponent = get component that are within the prefab
            }

            return false;

        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition); //find mouse position 
        }
    }
}