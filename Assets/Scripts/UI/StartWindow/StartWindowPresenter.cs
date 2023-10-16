using Game;

namespace UI.StartWindow
{
    public class StartWindowPresenter
    {
        private readonly StartWindow _startWindow;
        private readonly GameLifecycle _gameLifecycle;

        public StartWindowPresenter(StartWindow startWindow, GameLifecycle gameLifecycle)
        {
            _startWindow = startWindow;
            _gameLifecycle = gameLifecycle;
            _startWindow.PlayButton.onClick.AddListener(OnClickPlay);
        }

        private void OnClickPlay()
        {
            _gameLifecycle.StartGame();
        }
    }
}