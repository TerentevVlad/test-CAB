using Test2.Scripts;
using UnityEngine;

public static class ObjectViewRandomizer
{
    public static void RandomSkin(this ObjectView view)
    {
        Color color = new Color(
            Random.Range(0, 1.0f), 
            Random.Range(0, 1.0f),
            Random.Range(0, 1.0f));
        view.ChangeColor(color);

        Vector3 localScale = new Vector3(
            Random.Range(0.1f, 2f), 
            Random.Range(0.1f, 2f),
            Random.Range(0.1f, 2f));
        
        view.transform.localScale = localScale;
    }

    public static void RandomPosition(this ObjectView view, Bounds bounds)
    { 
        Vector3 GetRandomPositionInBounds()
        {
            var x = Random.Range(bounds.min.x, bounds.max.x);
            var z = Random.Range(bounds.min.z, bounds.max.z);
            
            
            return new Vector3(x, 0, z);
        }
        view.transform.position = GetRandomPositionInBounds();
    }
}