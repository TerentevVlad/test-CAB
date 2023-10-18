using System;
using System.Collections.Generic;
using UnityEngine;

namespace Test2.Scripts.ChunkSystem
{
    public class ChunkView : MonoBehaviour
    {
        [SerializeField] private Spawner _spawner;
        [SerializeField] private ChunkTrigger _trigger;
        public event Action<ChunkView> OnEnter;
        public event Action<ChunkView> OnExit;

        private BoxCollider _boxCollider;

        private List<ObjectView> _objectViews;
        private void Awake()
        {
            _boxCollider = GetComponent<BoxCollider>();
            _trigger.OnEnter += OnEnterInChunk;
            _trigger.OnExit += OnExitInChunk;
        }

        private void OnEnterInChunk(ChunkChanger changer)
        {
            _objectViews = _spawner.Spawn(_boxCollider.bounds, transform);
            OnEnter?.Invoke(this);
            
        } 
        
        private void OnExitInChunk(ChunkChanger changer)
        {
            if (_objectViews != null)
            {
                _spawner.Release(_objectViews);
            }
            _objectViews = null;
            OnExit?.Invoke(this);
           
        }

        private void OnDestroy()
        {
            _trigger.OnEnter -= OnEnterInChunk;
            _trigger.OnExit -= OnExitInChunk;
        }
    }
}