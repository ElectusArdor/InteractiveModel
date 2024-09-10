using System;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public Action<Vector3> NewPosition;

    private void OnMouseDown()
    {
        NewPosition?.Invoke(transform.position);
    }
}
