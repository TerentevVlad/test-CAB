using DI;

namespace UI.Game
{
    public class GameWindowInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<GameWindow>().FromInstance(GetComponent<GameWindow>());
            Container.Bind<GameWindowPresenter>();
        }
    }
}