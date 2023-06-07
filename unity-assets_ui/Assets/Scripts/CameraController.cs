using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float timeOffset;
    [SerializeField]
    private Vector3 posOffset = new(0, 0, -6);
    [SerializeField]
    private float mouseSensitivity = 3f;
    private float rotationX;
    private float rotationY;
    public bool isInverted;
    public GameObject PauseMenu;

    private void Update()
    {
        if (!PauseMenu.activeSelf)
        {
            transform.position = player.position + posOffset;
            RotateCamera();
        }
    }

    private void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = isInverted ? -Input.GetAxis("Mouse Y") * mouseSensitivity : Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationY += mouseX;
        rotationX += mouseY;

        rotationX = Mathf.Clamp(rotationX, -20, 40);
        rotationY = Mathf.Clamp(rotationY, -70, 70);

        transform.LookAt(player);
        transform.RotateAround(player.position, new Vector3(1, 0, 0), rotationX);
        transform.RotateAround(player.position, new Vector3(0, 1, 0), rotationY);
        player.forward = transform.forward;
    }
}
