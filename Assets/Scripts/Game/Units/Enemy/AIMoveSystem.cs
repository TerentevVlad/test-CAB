using System;
using Game.Levels;
using Game.Movement;

namespace Game.Units.Enemy
{
    public class AIMoveSystem : IDisposable
    {
        private readonly MoveHandler _moveHandler;
        private readonly LevelView _level;

        public AIMoveSystem(MoveHandler moveHandler, LevelView level)
        {
            _moveHandler = moveHandler;
            _level = level;

            _moveHandler.OnComplete += Run;
            Run();
        }

        private void Run()
        {
            var randomPositionInBounds = _level.GetRandomPositionInBounds();
            _moveHandler.Move(randomPositionInBounds);
        }

        public void Dispose()
        {
            _moveHandler.OnComplete -= Run;
        }
    }
}