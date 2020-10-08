using System.Collections;
using System.Collections.Generic;
using RPG.Core;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour, IAction
    {
        NavMeshAgent _navMeshAgent;

        Animator _animator;


        ActionScheduler _actionScheduler;
        //Creates Mover component to be added.

        // Update is called once per frame
        private void Start()
        {
            _actionScheduler = GetComponent<ActionScheduler>();

            _animator = GetComponent<Animator>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            UpdateAnimator();
        }


        //distinction between action start and just calling move to. 
        public void StartMoveAction(Vector3 destination)
        {
            _actionScheduler.StartAction(this);

            //deselecting whatever target we have and then moving 

            MoveTo(destination);
        }
        

        public void MoveTo(Vector3 destination)
        {
            _navMeshAgent.destination = destination;
            _navMeshAgent.isStopped = false;
        }


        public void Cancel()
        {
            _navMeshAgent.isStopped = true;
        }


        private void UpdateAnimator()
        {
            Vector3 velocity = _navMeshAgent.velocity;
            Vector3 localVelocity =
                transform.InverseTransformDirection(velocity); //converts from world coordinates to local coordinates

            float speed = localVelocity.z;

            _animator.SetFloat("forwardSpeed", speed); //matching animation speed with velocity 
        }
    }
}