using System;
using Game.Levels;
using UI.Game;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.Units.Player
{
    public class PlayerFactory
    {
        private readonly PlayerConfig _playerConfig;
        private readonly LevelView _levelView;
        private readonly PlayerContainer _playerContainer;

        public PlayerFactory(PlayerConfig playerConfig, LevelView levelView, PlayerContainer playerContainer)
        {
            _playerConfig = playerConfig;
            _levelView = levelView;
            _playerContainer = playerContainer;
        }

        public PlayerModel Create()
        {
            var playerView = Object.Instantiate(_playerConfig.PlayerView, _levelView.transform);
            var playerModel = new PlayerModel(playerView, _playerConfig.Health);

            void Dispose()
            {
                _playerContainer.Clear();
                playerModel.OnDispose -= Dispose;
            }
            playerModel.OnDispose += Dispose;
            _playerContainer.Set(playerModel);
            
            return playerModel;
        }
    }

    public class PlayerModel : IDisposable
    {
        private readonly PlayerView _view;
        
        public float Health { get; private set; }

        public event Action<float> OnChangeHealth;
        public event Action OnDispose;
        public PlayerModel(PlayerView view, float health)
        {
            _view = view;
            Health = health;
        }

        public void Dispose()
        {
            OnDispose?.Invoke();
            Object.Destroy(_view.gameObject);
        }

        public void TakeDamage(float damage)
        {
            Health -= damage;
            Health = Mathf.Max(Health, 0);
            OnChangeHealth?.Invoke(Health);
        }
    }
}