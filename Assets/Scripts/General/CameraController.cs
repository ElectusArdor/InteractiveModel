using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform containerTransform;
    [SerializeField] private float rotateSpeed = 1f;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float changeFocusSpeed = 1f;
    [SerializeField] private float maxDistance = 20f;
    [SerializeField] private float minDistance = 2f;

    private Vector3 rotation = Vector3.zero;
    private bool canMove;

    public Vector3 FocusPoint { get; set; }

    private void SwitchMoseControl()
    {
        if (Input.GetMouseButtonDown(1))
        {
            canMove = !canMove;
            if (canMove) Cursor.lockState = CursorLockMode.Locked;
            else Cursor.lockState = CursorLockMode.None;
        }
    }

    private void RotateCamera()
    {
        if (canMove)
        {
            var y = Input.GetAxis("Mouse X");
            var x = Input.GetAxis("Mouse Y");

            rotation += new Vector3(x, y, 0) * rotateSpeed;
            containerTransform.rotation = Quaternion.Euler(rotation.x, rotation.y, 0);
        }
    }

    private void MoveCamera()
    {
        if (canMove)
        {
            var move = Input.GetAxis("Mouse ScrollWheel") * moveSpeed;
            Vector3 newTransform = transform.localPosition + new Vector3(0, -move, move);
            float distance = newTransform.magnitude;
            if (distance <= maxDistance & distance >= minDistance) transform.localPosition = newTransform;
        }
    }

    private void MoveToFocus()
    {
        containerTransform.position = Vector3.Lerp(containerTransform.position, FocusPoint, changeFocusSpeed);
    }

    private void Update()
    {
        MoveToFocus();
        SwitchMoseControl();
        RotateCamera();
        MoveCamera();
    }
}
