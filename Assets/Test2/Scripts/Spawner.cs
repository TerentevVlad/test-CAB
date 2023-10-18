using System.Collections.Generic;
using UnityEngine;

namespace Test2.Scripts
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private ObjectView _objectViewPrefab;


        private void Awake()
        {
            for (int i = 0; i < 10; i++)
            {
                var objectView = Instantiate(_objectViewPrefab);
                objectView.RandomSkin();
            }
        }


        public List<ObjectView> Spawn(Bounds bounds, Transform parent)
        {
            var size = 1000;
            List<ObjectView> objectViews = new List<ObjectView>(size);
            for (int i = 0; i < size; i++)
            {
                var objectView = Instantiate(_objectViewPrefab);
                objectView.RandomSkin();
                objectView.RandomPosition(bounds);
                objectViews.Add(objectView);
            }

            return objectViews;
        }

        public void Release(List<ObjectView> objectViews)
        {
            foreach (var objectView in objectViews)
            {
                Destroy(objectView.gameObject);
            }
        }
    }
}