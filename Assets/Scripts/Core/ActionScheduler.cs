using System;
using UnityEngine;

namespace RPG.Core
{
    public class ActionScheduler : MonoBehaviour
    {
        IAction currentAction;

        public void StartAction(IAction action)
        {
            if (currentAction == action)
                return; 
            
            //if the processed action is the same as the currentaction. get outta there
            //cancel Fighter when movement starts, cancel movement went fighter starts. 


            if (currentAction != null)
            {
                

                currentAction.Cancel();
            }
            
            

            currentAction = action;
        }
    }
}