using UnityEngine;
using Unity.Collections;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TargetMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;
    public ARPlane Plane { get; set; }
    public NativeArray<Vector2> PlaneBoundary { get; set; }

    private void OnEnable()
    {
        Vector2 pos = PlaneBoundary[0];
        Instantiate(_prefab, Plane.transform.TransformPoint(new Vector3(pos.x, 0, pos.y)), Quaternion.identity);
    }
}
