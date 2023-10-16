using System;
using UnityEngine;

namespace Game.Triggers
{
    public class TriggerHandler<T> : MonoBehaviour where T : MonoBehaviour
    {
        public event Action<T> OnEnter;
        public event Action<T> OnExit;
        
        private void OnTriggerEnter2D (Collider2D other)
        {
            if (other.TryGetComponent(out T view))
            {
                OnEnter?.Invoke(view);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out T view))
            {
                OnExit?.Invoke(view);
            }
        }
    }
}