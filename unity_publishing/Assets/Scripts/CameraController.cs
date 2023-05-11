using UnityEngine;

/// <summary>
/// Represents the camera following the player.
/// </summary>
public class CameraController : MonoBehaviour
{
	/// <summary>
	/// Represents the player.
	/// </summary>
	public GameObject player;
	/// <summary>
	/// Represents the time lapse when the player move and the camera follows.
	/// </summary>
	public float timeOffset;
	/// <summary>
	/// Represents the distance between the camera and the player.
	/// </summary>
	public Vector3 posOffset;
	private Vector3 velocity;

	private void Start()
	{
		transform.position = player.transform.position;
	}

	private void Update()
	{
		transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);
	}
}
