using System;
using Game.Levels;
using Game.Triggers;
using Game.Units.Enemy;
using Object = UnityEngine.Object;

namespace Game.Units.Player
{
    public class DamageReceiver : IDisposable
    {
        private readonly Level _level;
        private readonly EnemyTrigger _playerViewEnemyTrigger;

        public DamageReceiver(PlayerView playerView, Level level)
        {
            _level = level;
            _playerViewEnemyTrigger = playerView.EnemyTrigger;
            
            _playerViewEnemyTrigger.OnEnter += OnEnemyTriggerEnter;
        }

        private void OnEnemyTriggerEnter(EnemyView obj)
        {
            _level.PlayerModel.TakeDamage(1);
            Object.Destroy(obj.gameObject);
        }

        public void Dispose()
        {
            _playerViewEnemyTrigger.OnEnter -= OnEnemyTriggerEnter;
        }
    }
}