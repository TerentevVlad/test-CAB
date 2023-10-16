using System;
using UnityEngine;

namespace Game
{
    public class UnityLifecycle : MonoBehaviour
    {

        public event Action OnTick;
        public event Action OnFixedTick;
        private void Update()
        {
            OnTick?.Invoke();
        }

        private void FixedUpdate()
        {
            OnFixedTick?.Invoke();
        }
    }
}