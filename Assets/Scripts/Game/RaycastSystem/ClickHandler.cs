using System;
using UnityEngine;

namespace Game.RaycastSystem
{
    public class ClickHandler
    {
        private readonly Camera _camera;
        private readonly UnityLifecycle _unityLifecycle;
        private readonly float _maxRaycastDistance = 1000;

        public event Action<Collider> OnRaycastHit;
        public event Action<Vector3> OnRaycastWorldPosition;

        public ClickHandler(Camera camera, UnityLifecycle unityLifecycle)
        {
            _camera = camera;
            _unityLifecycle = unityLifecycle;
            
            _unityLifecycle.OnTick += OnTick;
        }

        private void OnTick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                
                if (Physics.Raycast(ray, out hit, _maxRaycastDistance) == false) return;

                if (hit.collider.GetComponents<IRaycastable>() == null) return;

                OnRaycastHit?.Invoke(hit.collider.GetComponent<Collider>());
                OnRaycastWorldPosition?.Invoke(hit.point);
            }
        }
        
    }
}