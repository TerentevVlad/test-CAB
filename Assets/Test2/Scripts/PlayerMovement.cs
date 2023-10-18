using System;
using UnityEngine;

namespace Test2.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        private void LateUpdate()
        {
            transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        }
    }
}