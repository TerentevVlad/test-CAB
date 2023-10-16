using System;
using DG.Tweening;
using Game.Levels;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.Units.Fruit
{
    public class FruitSpawner : IDisposable
    {
        private readonly FruitConfig _fruitConfig;
        private readonly LevelView _levelView;
        private readonly FruitContainer _fruitsContainer;


        private Tween _tween;

        public FruitSpawner(FruitConfig fruitConfig, LevelView levelView, FruitContainer fruitsContainer)
        {
            _fruitConfig = fruitConfig;
            _levelView = levelView;
            _fruitsContainer = fruitsContainer;

            for (int i = 0; i < _fruitConfig.InitialFruits; i++)
            {
                SpawnFruit();
            }
            RunSpawner();
        }
        
        private void SpawnFruit()
        {
            Vector3 position = _levelView.GetRandomPositionInBounds();
            var fruitView = Object.Instantiate(
                _fruitConfig.FruitViewPrefab, 
                position, 
                Quaternion.identity, 
                _levelView.transform);
            
            var fruit = new Fruit(fruitView);

            void OnCollect()
            {
                fruit.OnCollect -= OnCollect;
                _fruitsContainer.Remove(fruit);
            }

            fruit.OnCollect += OnCollect;
            _fruitsContainer.Add(fruit);
        }
        
        private void RunSpawner()
        {
            _tween = DOVirtual.DelayedCall(_fruitConfig.CooldownRespawn, () =>
            {
                if (_fruitsContainer.Count < _fruitConfig.MaxFruits)
                {
                    SpawnFruit();
                }
            }).SetLoops(-1, LoopType.Restart);
        }

        public void Dispose()
        {
            _tween?.Kill();
        }
    }
}