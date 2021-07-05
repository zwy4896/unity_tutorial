using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial
{
    public class KeyboardInput : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            if(Input.GetKey(KeyCode.D))
            {
                VirtualInputManager.Instance.moveRight = true;
            }
            else
            {
                VirtualInputManager.Instance.moveRight = false;
            }
            if(Input.GetKey(KeyCode.A))
            {
                VirtualInputManager.Instance.moveLeft = true;
            }
            else
            {
                VirtualInputManager.Instance.moveLeft = false;
            }

            if(Input.GetKey(KeyCode.Space))
            {
                VirtualInputManager.Instance.jump = true;
            }
            else{
                VirtualInputManager.Instance.jump = false;
            }

        }
    }

}
