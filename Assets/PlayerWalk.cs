using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial
{
    public class PlayerWalk : CharacterStateBase
    {
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
           
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
           if(VirtualInputManager.Instance.moveRight && VirtualInputManager.Instance.moveLeft)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), false);
                return;
            }
            if(!VirtualInputManager.Instance.moveRight && !VirtualInputManager.Instance.moveLeft)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), false);
                return;
            }
            if(VirtualInputManager.Instance.moveRight)
            {
                GetCharacterControl(animator).transform.Translate(Vector3.forward * GetCharacterControl(animator).speed * Time.deltaTime);
                GetCharacterControl(animator).transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            if(VirtualInputManager.Instance.moveLeft)
            {
                GetCharacterControl(animator).transform.Translate(Vector3.forward * GetCharacterControl(animator).speed * Time.deltaTime);
                GetCharacterControl(animator).transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
           
        }
    }

}
