using UnityEngine;

/// <summary>
/// Represents the behavior of the coin.
/// </summary>
public class Rotator : MonoBehaviour
{
	private void Update()
	{
		transform.Rotate(45.0f * Time.deltaTime, 0f, 0f);
	}
}
