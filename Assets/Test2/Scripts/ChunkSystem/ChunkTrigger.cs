using System;
using UnityEngine;

public class ChunkTrigger : MonoBehaviour
{
    public event Action<ChunkChanger> OnEnter;
    public event Action<ChunkChanger> OnExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ChunkChanger mined))
        {
            OnEnter?.Invoke(mined);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out ChunkChanger mined))
        {
            OnExit?.Invoke(mined);
        }
    }
}