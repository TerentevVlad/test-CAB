using System;
using Game.Units.Enemy;
using Game.Units.Fruit;
using Game.Units.Player;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.Levels
{
    public class Level : IDisposable
    {
        public Game.Units.Player.PlayerModel PlayerModel { get; private set; }
        public LevelView View { get; }
        private readonly Camera _camera;
        private readonly LevelConfig _levelConfig;
        private readonly FruitContainer _fruitContainer;
        private readonly PlayerContainer _playerContainer;

        private FruitSpawner _fruitSpawner;
        
        private PlayerFactory _playerFactory;
        private EnemyFactory _enemyFactory;

        public Level(LevelView view, Camera camera, LevelConfig levelConfig, FruitContainer fruitContainer, PlayerContainer playerContainer)
        {
            View = view;
            _camera = camera;
            _levelConfig = levelConfig;
            _fruitContainer = fruitContainer;
            _playerContainer = playerContainer;

            var cameraOrthographicSize = _camera.orthographicSize;
            var ySize = cameraOrthographicSize * 2;
            var xSize = ySize * _camera.aspect;
            View.SetSize(new Vector2(xSize, ySize));
        }

        public void Run()
        {
            _fruitSpawner = new FruitSpawner(_levelConfig.FruitConfig, View, _fruitContainer);
            _playerFactory = new PlayerFactory(_levelConfig.PlayerConfig, View, _playerContainer);
            PlayerModel = _playerFactory.Create();
            _enemyFactory = new EnemyFactory(_levelConfig.EnemyConfig, View);
            _enemyFactory.Create();
        }

        public void Dispose()
        {
            _fruitContainer.Dispose();
            _fruitSpawner.Dispose();
            PlayerModel.Dispose();
            Object.Destroy(View.gameObject);
           
        }
    }
}