using System;
using Game.Units.Player;

namespace Game
{
    public class PlayerContainer
    {
        private PlayerModel _playerModel;

        public event Action<PlayerModel> OnAdd;
        public event Action<PlayerModel> OnRemove;


        public void Set(PlayerModel player)
        {
            _playerModel = player;
            OnAdd?.Invoke(_playerModel);
        }

        public void Clear()
        {
            OnRemove?.Invoke(_playerModel);
            _playerModel = null;
        }

        public PlayerModel Get() => _playerModel;
    }
}