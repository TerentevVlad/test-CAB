using Game;

namespace UI.EndGame
{
    public class EndGameWindowPresenter
    {
        private readonly EndGameWindow _view;
        private readonly ScoreController _scoreController;
        private readonly GameLifecycle _gameLifecycle;

        public EndGameWindowPresenter(EndGameWindow view, ScoreController scoreController, GameLifecycle gameLifecycle)
        {
            _view = view;
            _scoreController = scoreController;
            _gameLifecycle = gameLifecycle;
            OnChangeScore(0);
            _scoreController.OnChangeValue += OnChangeScore;
            
            _view.ReloadButton.onClick.AddListener(() =>
            {
                _gameLifecycle.StartGame();
            });
        }

        private void OnChangeScore(float _)
        {
            _view.CurrentScoreText.text = $"Current score {_scoreController.GetValue()}";
            _view.RecordScoreText.text = $"Record score {_scoreController.GetRecordValue()}";
        }
    }
}