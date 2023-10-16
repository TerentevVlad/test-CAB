using Game.Movement;
using Game.Triggers;
using UnityEngine;

namespace Game.Units.Player
{
    public class PlayerView : MonoBehaviour, IMovement
    {
        [field: SerializeField] public FruitTrigger FruitTrigger { get; private set; }
        [field: SerializeField] public EnemyTrigger EnemyTrigger { get; private set; }
        public Transform Transform => transform;
    }
}