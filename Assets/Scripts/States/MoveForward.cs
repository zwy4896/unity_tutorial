using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial
{
    [CreateAssetMenu(fileName ="newState", menuName ="Tutorial/AbilityData/MoveForward")]
    public class MoveForward : StateData
    {
        public AnimationCurve speedGraph;
        public float speed;
        public float distance;
        private bool self;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo StateInfo)
        {
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl c = characterState.GetCharacterControl(animator);
            if(c.jump)
            {
                animator.SetBool(TransitionParameter.Jump.ToString(), true);
            }
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
                c.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                if(!CheckFront(c))
                {
                    c.transform.Translate(Vector3.forward * speed * speedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
                }
            }
            if(c.moveLeft)
            {
                c.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                if(!CheckFront(c))
                {
                    c.transform.Translate(Vector3.forward * speed * speedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
                }
            }
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo StateInfo)
        {
        }

        bool CheckFront(CharacterControl characterControl)
        {
            foreach(GameObject o in characterControl.frontSpheres)
            {
                self = false;
                Debug.DrawRay(o.transform.position, characterControl.transform.forward * 0.3f, Color.yellow);
                RaycastHit hit;
                if(Physics.Raycast(o.transform.position, characterControl.transform.forward, out hit, distance))
                {
                    foreach(Collider c in characterControl.ragdollParts)
                    {
                        if(c.gameObject == hit.collider.gameObject)
                        {
                            self = true;
                            break;
                        }
                    }

                    if(!self)
                    {
                        return true;
                    }
                    return true;
                }
            }
            return false;
        }

    }

}
