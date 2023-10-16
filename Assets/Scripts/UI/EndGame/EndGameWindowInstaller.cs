using DI;

namespace UI.EndGame
{
    public class EndGameWindowInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container
                .Bind<EndGameWindow>()
                .FromInstance(GetComponent<EndGameWindow>());

            Container
                .Bind<EndGameWindowPresenter>();
        }
    }
}