using Game;
using Game.Units.Player;

namespace UI.Game
{
    public class GameWindowPresenter
    {
        private readonly GameWindow _gameWindow;
        private readonly ScoreController _scoreController;
        private readonly PlayerContainer _playerContainer;

        public GameWindowPresenter(GameWindow gameWindow, ScoreController scoreController, PlayerContainer playerContainer)
        {
            _gameWindow = gameWindow;
            _scoreController = scoreController;
            _playerContainer = playerContainer;
            _gameWindow.SetScore(_scoreController.GetValue());
            _scoreController.OnChangeValue += OnChangeScore;
            
            _playerContainer.OnAdd += OnInitPlayer;
            _playerContainer.OnRemove += OnRemovePlayer;
        }

        private void OnRemovePlayer(PlayerModel playerModel)
        {
            _gameWindow.SetHealth("");
            playerModel.OnChangeHealth -= _gameWindow.SetHealth;
        }

        private void OnInitPlayer(PlayerModel playerModel)
        {
            _gameWindow.SetHealth(playerModel.Health);
            playerModel.OnChangeHealth += _gameWindow.SetHealth;
        }

        private void OnChangeScore(float value)
        {
            _gameWindow.SetScore(value);
        }
    }
}