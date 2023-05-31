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
    [SerializeField]
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        orientation = GetComponent<Transform>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, -transform.up, 1.25f);

        TakeInput();
        rb.drag = groundDrag;

        if (transform.position.y < -30)
        {
            transform.position = new Vector3(0, 30, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();

        if (!isGrounded)
        {
            rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass * 2);
        }
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
