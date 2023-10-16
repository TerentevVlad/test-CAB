using Game.Levels;
using Game.Units.Player;
using UI;
using UI.EndGame;
using UI.Game;
using UI.StartWindow;

namespace Game
{
    public class GameLifecycle
    {
        private readonly WindowService _windowService;
        private readonly LevelController _levelController;
        private readonly ScoreController _scoreController;
        private readonly PlayerContainer _playerContainer;


        public GameLifecycle(
            WindowService windowService, 
            LevelController levelController, 
            ScoreController scoreController,
            PlayerContainer playerContainer)
        {
            _windowService = windowService;
            _levelController = levelController;
            _scoreController = scoreController;
            _playerContainer = playerContainer;
        }

        public void Run()
        {
            _windowService.Open<StartWindow>();
            _scoreController.Reset();
        }

        public void StartGame()
        {
            _scoreController.Reset();
            _windowService.Open<GameWindow>();
            _playerContainer.OnAdd += OnInitPlayer;
            _levelController.Create();
            
        }

        private void OnInitPlayer(PlayerModel playerModel)
        {
            void OnDied()
            {
                playerModel.OnChangeHealth -= OnChangeHealth;
                OnDiedPlayer();
            }
                
            void OnChangeHealth(float health)
            {
                if (health <= 0)
                {
                    OnDied();
                }
            }
            playerModel.OnChangeHealth += OnChangeHealth;
        }

        private void OnDiedPlayer()
        {
            _playerContainer.OnAdd -= OnInitPlayer;
            _playerContainer.Clear();
            _levelController.CloseLevel();
            _windowService.Open<EndGameWindow>();
        }
    }
}