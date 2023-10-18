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
                objectView.Random();
            }
        }
    
    
    }
}