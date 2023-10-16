using Game.Levels;
using UnityEngine;

namespace Game.Units.Enemy
{
    public class EnemyFactory
    {
        private readonly EnemyConfig _enemyConfig;
        private readonly LevelView _levelView;

        public EnemyFactory(EnemyConfig enemyConfig, LevelView levelView)
        {
            _enemyConfig = enemyConfig;
            _levelView = levelView;
        }

        public void Create()
        {
            for (int i = 0; i < _enemyConfig.NumEnemy; i++)
            {
                _levelView.GetRandomPositionInBounds();
                var enemyView = Object.Instantiate(
                    _enemyConfig.EnemyViewPrefab, 
                    _levelView.GetPointInRandomAngle(), 
                    Quaternion.identity,
                    _levelView.transform);
            }
        }
    }
}