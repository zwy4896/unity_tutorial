using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial
{
    public enum TransitionParameter
    {
        Move,
    }

    public class CharacterControl : MonoBehaviour
    {
        public float speed;
        public Animator animator;
    }

}
