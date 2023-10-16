using System;
using Game.Units.Fruit;

namespace Game.Units.Player
{
    public class FruitCollector : IDisposable

    {
        private readonly PlayerView _playerView;
        private readonly FruitContainer _fruitContainer;
        private readonly ScoreController _scoreController;

        public FruitCollector(PlayerView playerView, FruitContainer fruitContainer, ScoreController scoreController)
        {
            _playerView = playerView;
            _fruitContainer = fruitContainer;
            _scoreController = scoreController;

            _playerView.FruitTrigger.OnEnter += OnEnterFruitTrigger;
        }

        private void OnEnterFruitTrigger(FruitView fruitView)
        {
            Fruit.Fruit fruit = _fruitContainer.Get(fruitView);
            fruit.Collect();
            _scoreController.AddScore(1);
        }

        public void Dispose()
        {
            _playerView.FruitTrigger.OnEnter -= OnEnterFruitTrigger;
        }
    }
}