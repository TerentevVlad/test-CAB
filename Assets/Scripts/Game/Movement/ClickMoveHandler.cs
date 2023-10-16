using System;
using Game.RaycastSystem;
using UnityEngine;

namespace Game.Movement
{
    public class ClickMoveHandler : IDisposable
    {
        private readonly MoveHandler _moveHandler;
        private readonly ClickHandler _clickHandler;

        public ClickMoveHandler(MoveHandler moveHandler, ClickHandler clickHandler)
        {
            _moveHandler = moveHandler;
            _clickHandler = clickHandler;
            _clickHandler.OnRaycastWorldPosition += OnClick;
        }

        private void OnClick(Vector3 point)
        {
            _moveHandler.Move(point);
        }

        public void Dispose()
        {
            _clickHandler.OnRaycastWorldPosition -= OnClick;
        }
    }
}