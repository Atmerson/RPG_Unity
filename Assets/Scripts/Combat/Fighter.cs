using System;
using System.Runtime.InteropServices;
using RPG.Core;
using RPG.Movement;
using UnityEngine;


namespace RPG.Combat
{
    public class Fighter : MonoBehaviour,IAction
    {
        [SerializeField] float weaponRange = 2f;

        [SerializeField] float timebetweenattacks = 1f;
        
        Transform target;
        private float timeSinceLastAttack = 0;
        
        Mover _mover;
        Animator _animator;
        ActionScheduler _actionScheduler;
        
        
        

        private void Start()
        {
            _actionScheduler = GetComponent<ActionScheduler>();
            _animator = GetComponent<Animator>();
            _mover = GetComponent<Mover>();
        }

        private void Update()
        {
            //transform.position is the current position of character
            timeSinceLastAttack += Time.deltaTime;
            if (target == null) return; //no target

            if (!GetIsInRange())
            {
                _mover.MoveTo(target.position);
            }
            else
            {
                //in range. start attacking
                _mover.Cancel();
                AttackBehaviour();
            }
        }

        private void AttackBehaviour()
        {
            if (timeSinceLastAttack > timebetweenattacks)
            {
                _animator.SetTrigger("attack");
                timeSinceLastAttack = 0;
            }
            
            //expand to apply damage and stuff
        }


        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }


        public void Attack(CombatTarget combatTarget)
        {
            
            
             
            _actionScheduler.StartAction(this);
            
            target = combatTarget.transform;
            
            
        }

        public void Cancel()
        {
            target = null; //deselect enemy
            Debug.Log("get me outta here");
        }

        //Animation Event
        void Hit()
        {
            
        }
    }
}