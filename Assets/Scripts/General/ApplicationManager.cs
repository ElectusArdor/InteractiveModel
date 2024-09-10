using UnityEngine;

public class ApplicationManager : MonoBehaviour
{
    void Awake()
    {
        Application.targetFrameRate = 60;
        Cursor.lockState = CursorLockMode.None;
    }
}
