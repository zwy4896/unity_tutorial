using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial
{
    [CreateAssetMenu(fileName ="newState", menuName ="Tutorial/AbilityData/MoveForward")]
    public class MoveForward : StateData
    {
        public float speed;
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo StateInfo)
        {
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl c = characterState.GetCharacterControl(animator);
            if(c.moveRight && c.moveLeft)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), false);
                return;
            }
            if(!c.moveRight && !c.moveLeft)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), false);
                return;
            }
            if(c.moveRight)
            {
                c.transform.Translate(Vector3.forward * speed * Time.deltaTime);
                c.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            if(c.moveLeft)
            {
                c.transform.Translate(Vector3.forward * speed * Time.deltaTime);
                c.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo StateInfo)
        {
        }
    }

}
