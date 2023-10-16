using UnityEngine;

namespace Game.Levels
{
    public class LevelController
    {
        private readonly LevelView _levelViewPrefab;
        private readonly Transform _levelContainer;
        private readonly Camera _camera;

        private LevelView _levelView;

    
        public LevelController(LevelView levelViewPrefab, Transform levelContainer, Camera camera)
        {
            _levelViewPrefab = levelViewPrefab;
            _levelContainer = levelContainer;
            _camera = camera;
        }
        
        public void Create()
        {
            _levelView = Object.Instantiate(_levelViewPrefab, _levelContainer);
        }

        public void CloseLevel()
        {
            Object.Destroy(_levelView.gameObject);
        }
    }
}