using Game.Units.Enemy;
using Game.Units.Fruit;
using Game.Units.Player;

namespace Game.Levels
{
    public class LevelConfig
    {
        public FruitConfig FruitConfig { get; }
        public PlayerConfig PlayerConfig { get; }
        
        public EnemyConfig EnemyConfig { get; }

        public LevelConfig(FruitConfig fruitConfig, PlayerConfig playerConfig, EnemyConfig enemyConfig)
        {
            PlayerConfig = playerConfig;
            FruitConfig = fruitConfig;
            EnemyConfig = enemyConfig;
        }    
    }
}