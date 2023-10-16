using DI;
using Game.Movement;
using Game.Units.Enemy;
using Game.Units.Fruit;
using Game.Units.Player;
using UnityEngine;

namespace Game.Levels
{
    public class LevelInstaller : Installer
    {
        [SerializeField] private FruitView _fruitView;
        [SerializeField] private PlayerView _playerViewPrefab;
        [SerializeField] private EnemyView _enemyView;
        public override void InstallBindings()
        {
            Container
                .Bind<LevelView>()
                .FromInstance(GetComponent<LevelView>());
            
            var fruitConfig = new FruitConfig(_fruitView, 10, 30, 2);
            var playerConfig = new PlayerConfig(new MovementConfig(5), _playerViewPrefab, 3);
            var enemyConfig = new EnemyConfig(new MovementConfig(2), _enemyView, 5);
            var levelConfig = new LevelConfig(fruitConfig, playerConfig, enemyConfig);
            
            Container
                .Bind<FruitContainer>()
                .FromInstance(new FruitContainer());
            Container
                .Bind<LevelConfig>()
                .FromInstance(levelConfig);
            
            Container
                .Bind<Level>();
          
            Container
                .Bind<LevelRunner>();


        }
    }
}