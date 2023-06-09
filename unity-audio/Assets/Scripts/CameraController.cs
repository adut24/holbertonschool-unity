using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    public bool isInverted;
    public float timeOffset;
    public Vector3 posOffset = new(0, 0, -6);
    public float mouseSensitivity = 3f;
    private Transform player;
    private float rotationX;
    private float rotationY;
    private GameObject pauseMenu;

    private void Awake() => DontDestroyOnLoad(gameObject);

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        transform.position = player.position + posOffset;
        pauseMenu = FindObjectsOfType<Canvas>(true).First(canvas => canvas.gameObject.name == "PauseCanvas").gameObject;
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name.Contains("Level") && !player)
            Start();
        if (!pauseMenu.activeSelf)
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
    }
}
