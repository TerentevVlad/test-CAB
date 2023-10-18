using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Test2.Scripts
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private ObjectView _objectViewPrefab;

        private Pool _pool;
        private void Awake()
        {
            _pool = new Pool(_objectViewPrefab, 4000, transform);
        }


        public List<ObjectView> Spawn(Bounds bounds, Transform parent)
        {
            List<ObjectView> objectViews = _pool.Create(1000, (view) =>
            {
                view.RandomSkin();
                view.RandomPosition(bounds);
            });
            
            return objectViews;
        }

        public void Release(List<ObjectView> objectViews)
        {
            _pool.Release(objectViews);

            // foreach (var objectView in objectViews)
            // {
            //     Object.Destroy(objectView.gameObject);
            // }
        }
    }
}