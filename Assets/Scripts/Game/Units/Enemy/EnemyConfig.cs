using Game.Movement;

namespace Game.Units.Enemy
{
    public class EnemyConfig
    {
        public int NumEnemy { get; }
        public EnemyView EnemyViewPrefab { get; }
        public MovementConfig MovementConfig { get; }

        public EnemyConfig(MovementConfig movementConfig, EnemyView enemyView, int numEnemy)
        {
            NumEnemy = numEnemy;
            EnemyViewPrefab = enemyView;
            MovementConfig = movementConfig;
        }
    }
}