using System;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public Action<Vector3> NewPosition;

    /// <summary>
    /// Делаем из мухи слона
    /// </summary>
    private void OnMouseDown()
    {
        NewPosition?.Invoke(transform.position);
    }
}
