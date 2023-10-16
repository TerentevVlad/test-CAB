using System.Collections.Generic;
using Game.Units.Fruit;

namespace Game
{
    public class FruitContainer
    {
        private Dictionary<FruitView, Fruit> _fruitsContainer;

        public int Count => _fruitsContainer.Count;

        public FruitContainer()
        {
            _fruitsContainer = new Dictionary<FruitView, Fruit>();
        }

        public void Add(Fruit fruit)
        {
            _fruitsContainer.Add(fruit.View, fruit);
        }

        public void Remove(Fruit fruit)
        {
            _fruitsContainer.Remove(fruit.View);
            fruit.Dispose();
        }

        public Fruit Get(FruitView fruitView)
        {
            return _fruitsContainer[fruitView];
        }

        public void Dispose()
        {
            foreach (var fruitsContainerValue in _fruitsContainer.Values)
            {
                fruitsContainerValue.Dispose();
            }
            _fruitsContainer.Clear();
        }
    }
}