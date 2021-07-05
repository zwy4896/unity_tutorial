using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial
{
    public class TestCube : MonoBehaviour
    {
        public float speed = 5;
        // Update is called once per frame
        void Update()
        {
            if(VirtualInputManager.Instance.moveRight)
            {
                this.gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
                this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            if(VirtualInputManager.Instance.moveLeft)
            {
                this.gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
                this.gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);

            }

        }
    }

}
