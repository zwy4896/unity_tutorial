using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial
{
    [CreateAssetMenu(fileName ="newState", menuName ="Tutorial/AbilityData/GroundDetector")]
    public class GroundDetector : StateData
    {
        [Range(0.01f, 1f)]
        public float checkTime;
        public float distance;
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo StateInfo)
        {
        }
        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl c = characterState.GetCharacterControl(animator);
            if(stateInfo.normalizedTime >= checkTime)
            {
                if(IsGrounded(c))
                {
                    animator.SetBool(TransitionParameter.Grounded.ToString(), true);
                }
                else
                {
                    animator.SetBool(TransitionParameter.Grounded.ToString(), false);
                }
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo StateInfo)
        {
        }

        bool IsGrounded(CharacterControl characterControl)
        {
            if(characterControl.RIGID_BODY.velocity.y > -0.001f && characterControl.RIGID_BODY.velocity.y <= 0f)
            {
                return true;
            }

            if(characterControl.RIGID_BODY.velocity.y < 0f)
            {
                foreach(GameObject o in characterControl.bottomSpheres)
                {
                    Debug.DrawRay(o.transform.position, -Vector3.up * 0.7f, Color.yellow);
                    RaycastHit hit;
                    if(Physics.Raycast(o.transform.position, -Vector3.up, out hit, distance))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }

}
