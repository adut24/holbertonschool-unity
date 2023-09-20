using UnityEngine;

/// <summary>
/// Makes the ammunitions follow the camera.
/// </summary>
public class FollowCamera : MonoBehaviour
{
    public float distanceFromCamera = 2f;

    private void Update()
    {
        transform.position = Camera.main.transform.position + Camera.main.transform.forward * distanceFromCamera;
    }
}
