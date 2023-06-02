using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float timeOffset;
    [SerializeField]
    private Vector3 posOffset = new(0, 0, -6);
    private Vector3 velocity;
    [SerializeField]
    private float mouseSensitivity = 3f;
    private float rotationY;
    private float rotationX;
    public bool isInverted;

    private void Awake() => DontDestroyOnLoad(gameObject);

    private void Update()
    {
        if (SceneManager.GetActiveScene().name.Contains("Level") && !player)
        {
            player = GameObject.FindWithTag("Player").GetComponent<Transform>();
            transform.position = player.position + posOffset;
            transform.eulerAngles = new(9, 0, 0);
        }
        if (player)
        {
            transform.position = Vector3.SmoothDamp(transform.position, player.position + posOffset, ref velocity, timeOffset);

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
}