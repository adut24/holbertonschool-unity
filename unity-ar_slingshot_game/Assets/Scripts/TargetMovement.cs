using UnityEngine;

/// <summary>
/// Manages the target's movements.
/// </summary>
public class TargetMovement : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed;

    private float _minX;
    private float _maxX;
    private float _minZ;
    private float _maxZ;
    private Vector3 _targetPosition;

    public Vector2[] PlaneBoundary { get; set; }

    private void Start()
    {
        AssignMinMaxValue();
        RandomizeTargetPosition();
    }

    private void Update() => MoveTarget();

    private void MoveTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _targetPosition) < 0.1f)
            RandomizeTargetPosition();
    }

    private void AssignMinMaxValue()
    {
        _minX = PlaneBoundary[0].x;
        _maxX = PlaneBoundary[0].x;
        _minZ = PlaneBoundary[0].y;
        _maxZ = PlaneBoundary[0].y;

        for (int i = 1; i < PlaneBoundary.Length; i++)
        {
            _minX = Mathf.Min(_minX, PlaneBoundary[i].x);
            _maxX = Mathf.Max(_maxX, PlaneBoundary[i].x);
            _minZ = Mathf.Min(_minZ, PlaneBoundary[i].y);
            _maxZ = Mathf.Max(_maxZ, PlaneBoundary[i].y);
        }
    }

    private void RandomizeTargetPosition()
    {
        float randomX = Random.Range(_minX, _maxX);
        float randomZ = Random.Range(_minZ, _maxZ);

        _targetPosition = new Vector3(randomX, transform.position.y, randomZ);
    }
}
