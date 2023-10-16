using DI;
using Game.Levels;
using Game.Movement;

namespace Game.Units.Enemy
{
    public class EnemyInstaller : Installer
    {
        public override void InstallBindings()
        {
            var enemyView = GetComponent<EnemyView>();
            Container.Bind<EnemyView>()
                .FromInstance(enemyView);
            
            Container
                .Bind<IMovement>()
                .FromInstance(enemyView);

            Container
                .Bind<MovementConfig>()
                .FromInstance(Container.Resolve<LevelConfig>().EnemyConfig.MovementConfig);
            
            Container
                .Bind<MoveHandler>();

            Container
                .Bind<AIMoveSystem>();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            
            Container.Resolve<AIMoveSystem>().Dispose(); 
            Container.Resolve<MoveHandler>().Dispose();
        }
    }
}