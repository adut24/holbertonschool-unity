using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float timeOffset;
    public Vector3 posOffset;
    private Vector3 velocity;
    public float mouseSensitivity = 3f;
    private float rotationY;
    private float rotationX;


    private void Start()
    {
        transform.position = player.position;
        transform.eulerAngles = new Vector3(9f, 0, 0);
    }

    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.position + posOffset, ref velocity, timeOffset);

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

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
