namespace DI
{
    public class SceneContext : RunnableContext
    {
        private void Awake()
        {
            
            DiContainer = new DIContainer();
            Run();
        }
    }
}