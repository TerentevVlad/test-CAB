namespace Game
{
    public class GameLifecycleRunner
    {
        public GameLifecycleRunner(GameLifecycle gameLifecycle)
        {
            gameLifecycle.Run();
        }
    }
}