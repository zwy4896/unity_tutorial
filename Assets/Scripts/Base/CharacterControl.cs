using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial
{
    public enum TransitionParameter
    {
        Move,
        Jump,
        ForceTransition,
    }

    public class CharacterControl : MonoBehaviour
    {
        public float speed;
        public Animator animator;
        public bool moveRight;
        public bool moveLeft;
        public bool jump;
    }

}
