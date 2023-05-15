using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Transform orientation;
    private Vector3 moveDirection;
    private float horizontalInput;
    private float verticalInput;
    public float speed;
    public float groundDrag;
    public float jumpHeight;
    public float gravityScale = 5;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        orientation = GetComponent<Transform>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        TakeInput();
        rb.drag = groundDrag;
        if (Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(transform.position, -transform.up, 1.1f))
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
        rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);
    }

    private void TakeInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = (orientation.forward * verticalInput) + (orientation.right * horizontalInput);
        rb.AddForce(moveDirection.normalized * speed * 10f, ForceMode.Force);
    }
}
