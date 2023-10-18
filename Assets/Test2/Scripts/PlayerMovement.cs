using System;
using UnityEngine;

namespace Test2.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 50;
        [SerializeField] private Transform _camera;

        private void Update()
        {
            transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Time.deltaTime * _speed;
        }

        private void LateUpdate()
        {
            _camera.transform.position = transform.position;
        }
    }
}