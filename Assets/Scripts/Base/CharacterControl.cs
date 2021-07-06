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
        public List<GameObject> frontSpheres = new List<GameObject>();
        private Rigidbody rigid;

        public float gravityMultiplier;
        public float pullMultiplier;
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
            GameObject topFront = CreateEdgeSphere(new Vector3(0f, top, front));

            bottomFront.transform.parent = this.transform;
            bottomBack.transform.parent = this.transform;
            topFront.transform.parent = this.transform;

            bottomSpheres.Add(bottomBack);
            bottomSpheres.Add(bottomFront);

            frontSpheres.Add(bottomFront);
            frontSpheres.Add(topFront);

            float horSec = (bottomFront.transform.position - bottomBack.transform.position).magnitude / 5f;
            CreateMidSpheres(bottomFront, -this.transform.forward , horSec, 4, bottomSpheres);

            float verSec = (bottomFront.transform.position - topFront.transform.position).magnitude / 10f;
            CreateMidSpheres(bottomFront, this.transform.up , verSec, 9, frontSpheres);
        }
        public void FixedUpdate()
        {
            if(RIGID_BODY.velocity.y < 0f)
            {
                RIGID_BODY.velocity -= (Vector3.up * gravityMultiplier);
            }
            if(RIGID_BODY.velocity.y > 0f && !jump)
            {
                RIGID_BODY.velocity -= (Vector3.up * pullMultiplier);
            }
        }
        public void CreateMidSpheres(GameObject start, Vector3 dir, float sec, int interations, List<GameObject> spheresList)
        {
            for (int i = 0; i < interations; i++)
            {
                Vector3 pos = start.transform.position + (dir * sec * (i+1));

                GameObject newObj = CreateEdgeSphere(pos);
                newObj.transform.parent = this.transform;
                spheresList.Add(newObj);
            }

        }

        public GameObject CreateEdgeSphere(Vector3 pos)
        {
            GameObject obj = Instantiate(ColliderEdgePrefab, pos, Quaternion.identity);
            return obj;
        }
    }

}
