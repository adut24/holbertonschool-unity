using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text collectedCoinsText;
    public Rigidbody2D rb;
    public int collectedCoins;
    public int lives;
    public int score;
    public float moveSpeed;
    public bool isGoingForward;
    private Vector2 moveDirection;

    private void Update()
    {
        ProcessInputs();
        isGoingForward = moveDirection.x > 0;
        if (collectedCoins == 100)
            IncreaseNumberLife();
    }
    
    void FixedUpdate() => Move();

    private void IncreaseNumberLife()
    {
        lives++;
        collectedCoins = 0;
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        moveDirection = new Vector2(moveX, 0).normalized;
    }

    void Move() => rb.velocity = new Vector2(moveDirection.x * moveSpeed, 0);
}
