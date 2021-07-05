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
        Grounded,
    }

    public class CharacterControl : MonoBehaviour
    {
        public Animator animator;
        public bool moveRight;
        public bool moveLeft;
        public bool jump;
        public GameObject ColliderEdgePrefab;
        public List<GameObject> bottomSpheres = new List<GameObject>();
        private Rigidbody rigid;
        public Rigidbody RIGID_BODY
        {
            get
            {
                if(rigid == null)
                {
                    rigid = GetComponent<Rigidbody>();
                }
                return rigid;
            }
        }

        private void Awake()
        {
            BoxCollider box = GetComponent<BoxCollider>();

            float bottom = box.bounds.center.y - box.bounds.extents.y;
            float top = box.bounds.center.y + box.bounds.extents.y;
            float front = box.bounds.center.z + box.bounds.extents.z;
            float back = box.bounds.center.z - box.bounds.extents.z;

            GameObject bottomFront = CreateEdgeSphere(new Vector3(0f, bottom, front));
            GameObject bottomBack = CreateEdgeSphere(new Vector3(0f, bottom, back));

            bottomFront.transform.parent = this.transform;
            bottomBack.transform.parent = this.transform;

            bottomSpheres.Add(bottomBack);
            bottomSpheres.Add(bottomFront);

            float sec = (bottomFront.transform.position - bottomBack.transform.position).magnitude / 5f;
            for (int i = 0; i < 5; ++i)
            {
                Vector3 pos = bottomBack.transform.position + (Vector3.forward * sec * (i+1));
                GameObject newObj = CreateEdgeSphere(pos);
                newObj.transform.parent = this.transform;
                bottomSpheres.Add(newObj);
            }
        }

        public GameObject CreateEdgeSphere(Vector3 pos)
        {
            GameObject obj = Instantiate(ColliderEdgePrefab, pos, Quaternion.identity);
            return obj;
        }
    }

}
