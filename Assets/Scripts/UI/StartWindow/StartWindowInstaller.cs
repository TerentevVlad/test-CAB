using DI;

namespace UI.StartWindow
{
    public class StartWindowInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container
                .Bind<UI.StartWindow.StartWindow>()
                .FromInstance(GetComponent<UI.StartWindow.StartWindow>());

            Container
                .Bind<StartWindowPresenter>();
        }
    }
}