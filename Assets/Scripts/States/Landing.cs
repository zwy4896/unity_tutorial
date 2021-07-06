using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial
{
    [CreateAssetMenu(fileName ="newState", menuName ="Tutorial/AbilityData/Landing")]
    public class Landing : StateData
    {
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo StateInfo)
        {
            animator.SetBool(TransitionParameter.Jump.ToString(), false);
            animator.SetBool(TransitionParameter.Move.ToString(), false);
        }
        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo StateInfo)
        {
        }
    }
}