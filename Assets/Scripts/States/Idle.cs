using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial
{
    [CreateAssetMenu(fileName ="newState", menuName ="Tutorial/AbilityData/Idle")]
    public class Idle : StateData
    {
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo StateInfo)
        {
            animator.SetBool(TransitionParameter.Jump.ToString(), false);
        }
        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl c = characterState.GetCharacterControl(animator);
            if(c.jump)
            {
                animator.SetBool(TransitionParameter.Jump.ToString(), true);
            }
            if(c.moveRight)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), true);
            }
            if(c.moveLeft)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), true);
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo StateInfo)
        {
        }
    }

}

