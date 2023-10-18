using System.Collections.Generic;
using UnityEngine;

namespace Test2.Scripts
{
    public class Pool
    {
        private readonly ObjectView _prefab;
        private readonly Transform _container;

        private List<ObjectView> _freeInstance;
        public Pool(ObjectView prefab, int startSize, Transform container)
        {
            _freeInstance = new List<ObjectView>(startSize);
            _prefab = prefab;
            _container = container;

            Instantiate(startSize);
        }
        public List<ObjectView> Create(int num)
        {
            if (num >= _freeInstance.Count)
            {
                var dif = num - _freeInstance.Count;
                Instantiate(dif);
            }

            var objectViews = _freeInstance.GetRange(0, num);
            foreach (var objectView in objectViews)
            {
                objectView.gameObject.SetActive(true);
            }
            
            _freeInstance.RemoveRange(0, num);

            return objectViews;
        }

        public void Release(List<ObjectView> objectViews)
        {
            foreach (var objectView in objectViews)
            {
                objectView.gameObject.SetActive(false);
                //objectView.transform.SetParent(_container);
            }
            _freeInstance.AddRange(objectViews);
        }

        private void Instantiate(int num)
        {
            for (int i = 0; i < num; i++)
            {
                var instance = Object.Instantiate(_prefab, _container);
                //instance.gameObject.SetActive(false);
                _freeInstance.Add(instance);
            }
        }
        
    }
}