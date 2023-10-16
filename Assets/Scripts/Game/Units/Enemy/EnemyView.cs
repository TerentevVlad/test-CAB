using Game.Movement;
using UnityEngine;

namespace Game.Units.Enemy
{
    public class EnemyView : MonoBehaviour, IMovement
    {
        public Transform Transform => transform;
    }

}