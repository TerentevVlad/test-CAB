using System;
using Object = UnityEngine.Object;

namespace Game.Units.Fruit
{
    public class Fruit
    {
        public FruitView View { get; private set; }
        public event Action OnCollect;
        
        public Fruit(FruitView view)
        {
            View = view;
        }

        public void Collect()
        {
            OnCollect?.Invoke();
        }

        public void Dispose()
        {
            Object.Destroy(View.gameObject);
            View = null;
        }
    }
}