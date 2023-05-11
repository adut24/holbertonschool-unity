using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Represents the control of the player
/// </summary>
public class PlayerController : MonoBehaviour
{
	private Rigidbody rb;
	private Transform orientation;
	private Vector3 moveDirection;
	private float horizontalInput;
	private float verticalInput;
	/// <summary>
	/// Represents the movement speed.
	/// </summary>
	public float speed;
	/// <summary>
	/// Represents the friction with the ground.
	/// </summary>
	public float groundDrag;
	private int score;
	/// <summary>
	/// Represents the remaining life of the player.
	/// </summary>
	public int health = 5;
	/// <summary>
	/// Represents the score displayed of the player.
	/// </summary>
	public Text scoreText;
	/// <summary>
	/// Represents the remaining life displayed of the player.
	/// </summary>
	public Text healthText;
	/// <summary>
	/// Represents the message displayed when the player dies of touches the goal.
	/// </summary>
	public Image winLoseImage;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		orientation = GetComponent<Transform>();
		rb.freezeRotation = true;
	}

	private void Update()
	{
		if (health == 0)
		{
			SetMessage("Game Over!", Color.white, Color.red);
			StartCoroutine(LoadScene(3));
		}
		TakeInput();
		SetScoreText();
		SetHealthText();
		rb.drag = groundDrag;

		if (Input.GetKey(KeyCode.Escape))
		{
			SceneManager.LoadScene("menu");
		}
	}

	private void FixedUpdate()
	{
		MovePlayer();
	}

	private void TakeInput()
	{
		horizontalInput = Input.GetAxisRaw("Horizontal");
		verticalInput = Input.GetAxisRaw("Vertical");
	}

	private void MovePlayer()
	{
		moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
		rb.AddForce(moveDirection.normalized * speed * 10f, ForceMode.Force);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Pickup"))
		{
			score++;
			Destroy(other.gameObject);
		}
		else if (other.CompareTag("Trap"))
		{
			health--;
		}
		else if (other.CompareTag("Goal"))
		{
			SetMessage("You Win!", Color.black, Color.green);
			StartCoroutine(LoadScene(3));
		}
	}

	private void SetScoreText() => scoreText.text = "Score: " + score;

	private void SetHealthText() => healthText.text = "Health: " + health;

	private void SetMessage(string message, Color textColor, Color backgroundColor)
	{
		winLoseImage.gameObject.SetActive(true);
		Text winLoseText = winLoseImage.GetComponentInChildren<Text>();
		winLoseText.text = message;
		winLoseText.color = textColor;
		winLoseImage.color = backgroundColor;
	}

	private IEnumerator LoadScene(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
