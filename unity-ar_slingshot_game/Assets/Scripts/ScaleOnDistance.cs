using UnityEngine;

public class ScaleOnDistance : MonoBehaviour
{
    private Transform _arCamera;

    private void Start() => _arCamera = Camera.main.transform;

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, _arCamera.position);
        float scaleFactor = CalculateScaleFactor(distance);

        transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
    }

    private float CalculateScaleFactor(float distance)
    {
        float scaleFactor = Mathf.Clamp01(1 - (distance / 5f));

        return Mathf.Lerp(0.0002f, 0.15f, scaleFactor);
    }
}
