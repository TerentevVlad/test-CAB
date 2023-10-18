using Test2.Scripts;
using UnityEngine;

public static class ObjectViewRandomizer
{
    public static void Random(this ObjectView view)
    {
        Color color = new Color(
            UnityEngine.Random.Range(0, 1.0f), 
            UnityEngine.Random.Range(0, 1.0f),
            UnityEngine.Random.Range(0, 1.0f));
        view.ChangeColor(color);

        Vector3 localScale = new Vector3(
            UnityEngine.Random.Range(0.1f, 2f), 
            UnityEngine.Random.Range(0.1f, 2f),
            UnityEngine.Random.Range(0.1f, 2f));
        
        view.transform.localScale = localScale;
    }
}