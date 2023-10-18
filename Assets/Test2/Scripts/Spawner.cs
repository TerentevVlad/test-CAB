using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Test2.Scripts
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private ObjectView _objectViewPrefab;

        private Pool _pool;
        private void Awake()
        {
            _pool = new Pool(_objectViewPrefab, 2000, transform);
        }


        public List<ObjectView> Spawn(Bounds bounds)
        {
            var size = 1000;
            List<ObjectView> objectViews = _pool.Create(size);
            for (int i = 0; i < size; i++)
            {
                var objectView = objectViews[i];
                objectView.RandomSkin();
                objectView.RandomPosition(bounds);
                objectViews.Add(objectView);
            }

            return objectViews;
        }

        public void Release(List<ObjectView> objectViews)
        {
            _pool.Release(objectViews);
        }
    }
}