using DI;
using Game.Levels;
using Game.Movement;

namespace Game.Units.Player
{
    public class PlayerInstaller : Installer
    {
        public override void InstallBindings()
        {
            var playerView = GetComponent<PlayerView>();
            Container
                .Bind<PlayerView>()
                .FromInstance(playerView);
            
            Container
                .Bind<IMovement>()
                .FromInstance(playerView);

            Container
                .Bind<MovementConfig>()
                .FromInstance(Container.Resolve<LevelConfig>().PlayerConfig.MovementConfig);
            
            Container
                .Bind<MoveHandler>();

            Container
                .Bind<ClickMoveHandler>();

            Container
                .Bind<FruitCollector>();

            Container
                .Bind<DamageReceiver>();
        }
        
        protected override void OnDestroy()
        {
            base.OnDestroy();
            
            Container.Resolve<DamageReceiver>().Dispose();
            Container.Resolve<ClickMoveHandler>().Dispose();
            Container.Resolve<FruitCollector>().Dispose();
            Container.Resolve<MoveHandler>().Dispose();
        }
    }
}