using DI;
using Game.Levels;
using Game.RaycastSystem;
using UnityEngine;

namespace Game
{
    public class GameLifecycleInstaller : Installer
    {
        [SerializeField] private Transform _levelContainer;
        [SerializeField] private LevelView _levelViewPrefab;
        [SerializeField] private Camera _camera;

        public override void InstallBindings()
        {
            Container
                .Bind<Camera>()
                .FromInstance(_camera);
            
            Container
                .Bind<ScoreController>();

            Container
                .Bind<PlayerContainer>();

            Container
                .Bind<GameLifecycle>();
            
            
            Container
                .Bind<UnityLifecycle>()
                .FromInstance(GetComponent<UnityLifecycle>());
            

            Container
                .Bind<LevelController>()
                .FromInstance(new LevelController(_levelViewPrefab, _levelContainer, _camera));
            
            Container
                .Bind<ClickHandler>();
            
            Container
                .Bind<GameLifecycleRunner>();
        }
    }
}