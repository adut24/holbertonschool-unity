using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private PlayerController playerController;
    public float timeOffset;
    public Vector3 posOffset;
    private Vector3 velocity;

    private void Start()
    {
        transform.position = new Vector3(player.transform.position.x, posOffset.y, posOffset.z);
        playerController = player.GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (transform.position.y < 2)
            transform.position = new Vector3(transform.position.x, posOffset.y, posOffset.z);
        if (playerController.isGoingForward && player.transform.position.x > transform.position.x / 2)
            MoveCamera();
    }

    private void MoveCamera()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);
    }
}
