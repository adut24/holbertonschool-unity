using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float timeOffset;
    public Vector3 posOffset;
    private Vector3 velocity;
    public float mouseSensitivity = 0.5f;
    private Vector3 currentRotation;
    private float rotationY;
    private float rotationX;


    private void Start()
    {
        transform.position = player.position;
    }

    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.position + posOffset, ref velocity, timeOffset);
        // float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        // float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // rotationY += mouseX;
        // rotationX += mouseY;

        // rotationX = Mathf.Clamp(rotationX, -40, 40);
        // Vector3 nextRotation = new Vector3(rotationX, rotationY);
        // currentRotation = Vector3.SmoothDamp(currentRotation, nextRotation, ref velocity, 0.3f);
        // transform.localEulerAngles += currentRotation;
        // transform.position = player.position - (transform.forward * 3f);
    }
}
