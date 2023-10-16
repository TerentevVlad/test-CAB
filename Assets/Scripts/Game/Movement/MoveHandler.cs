using System;
using DG.Tweening;
using UnityEngine;

namespace Game.Movement
{
    public class MoveHandler : IDisposable
    {
        private readonly IMovement _movementView;
        private readonly MovementConfig _movementConfig;

        private Tween _tween;

        public event Action OnComplete;


        public MoveHandler(IMovement movementView, MovementConfig movementConfig)
        {
            _movementView = movementView;
            _movementConfig = movementConfig;
        }

        public void Move(Vector3 targetPosition)
        {
            _tween?.Kill();
            
            float distance = Vector3.Distance(_movementView.Transform.position, targetPosition);
            float time = distance / _movementConfig.Speed;
            _tween = _movementView.Transform.DOMove(targetPosition, time)
                .SetEase(Ease.Linear)
                .OnComplete(() => OnComplete?.Invoke());
        }

        public void Dispose()
        {
            _tween?.Kill();
            _tween = null;
        }
    }
}