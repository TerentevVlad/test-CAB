using UnityEngine;

namespace Test2.Scripts
{
    public class ObjectView : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer;

        public void ChangeColor(Color color)
        {
            var meshRendererMaterial = _meshRenderer.material;
            meshRendererMaterial.color = color;
        }
    }
    
  
}