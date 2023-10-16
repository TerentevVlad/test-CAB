using Game.RaycastSystem;
using UnityEngine;

namespace Game.Levels
{
    public class LevelView : MonoBehaviour, IRaycastable
    {
        [SerializeField] private BoxCollider _boxCollider;

        private Bounds Bounds => _boxCollider.bounds;

        public Vector2 GetRandomPositionInBounds()
        {
            var x = Random.Range(Bounds.min.x, Bounds.max.x);
            var y = Random.Range(Bounds.min.y, Bounds.max.y);
            return new Vector2(x, y);
        }
        
        public Vector2 GetPointInRandomAngle()
        {
            var range = Random.Range(0, 2);
            var x = range == 0 ? Bounds.min.x : Bounds.max.x;
            
            range = Random.Range(0, 2);
            var y = range == 0 ? Bounds.min.y : Bounds.max.y;
            
            return new Vector2(x, y);
        }
        
        public void SetSize(Vector2 size)
        {
            _boxCollider.size = new Vector3(size.x, size.y);
        }
    }
}