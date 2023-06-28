using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    private Vector3 moveDirection;
    public float speed;
    public float groundDrag;
    private float horizontalInput;
    private float verticalInput;
    public float jumpHeight = 5f;
    public float gravityScale = 9.8f;
    [SerializeField]
    private bool isGrounded;
    public Animator animator;
    private Transform modelTransform;
    private Vector3 initialOffset;
    private Quaternion targetRotation;
    public float rotationSpeed = 10f;

    private void Start()
    {
        modelTransform = transform.GetChild(0);
        initialOffset = modelTransform.position - transform.position;
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, -transform.up, 1.25f);
        TakeInput();
        rb.drag = groundDrag;
        if (transform.position.y < -30)
            transform.position = new Vector3(0, 30, 0);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            Jump();
        if (moveDirection != Vector3.zero)
            targetRotation = Quaternion.LookRotation(moveDirection);
    }

    private void FixedUpdate()
    {
        MovePlayer();
        if (!isGrounded)
            rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass * 2);
    }

    private void TakeInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
    }

    private void MovePlayer()
    {
        moveDirection = (transform.forward * verticalInput) + (transform.right * horizontalInput);
        animator.SetBool("IsMoving", (Mathf.Abs(verticalInput) > 0) || (Mathf.Abs(horizontalInput) > 0));
        rb.AddForce(moveDirection * speed * 10f, ForceMode.Force);
        modelTransform.rotation = Quaternion.Slerp(modelTransform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        modelTransform.position = transform.position + initialOffset;
    }

    private void Jump() => rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
}
