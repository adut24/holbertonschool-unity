using System.Collections.Generic;
using TMPro;
using UnityEngine;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

/// <summary>
/// Manages the detection of the planes.
/// </summary>
[RequireComponent(typeof(ARRaycastManager), typeof(ARPlaneManager))]
public class PlaneDetectionManager : MonoBehaviour
{
    private const string SELECT_PLANE = "SELECT A PLANE";

    [SerializeField]
    private ARPlaneManager _planeManager;
    [SerializeField]
    private ARRaycastManager _raycastManager;
    [SerializeField]
    private Image _backgroundImage;
    [SerializeField]
    private TextMeshProUGUI _text;
    [SerializeField]
    private Button _startButton;
    [SerializeField]
    private GameObject _prefab;
    [SerializeField]
    private int _numberTarget = 5;
    private List<ARRaycastHit> _hits = new List<ARRaycastHit>();
    private bool _planeSelectionDone = false;


    private void OnEnable()
    {
        _planeManager.planesChanged += OnPlanesChanged;
        EnhancedTouch.EnhancedTouchSupport.Enable();
        EnhancedTouch.Touch.onFingerDown += OnFingerDown;
    }

    private void OnDisable()
    {
        _planeManager.planesChanged -= OnPlanesChanged;
        EnhancedTouch.EnhancedTouchSupport.Disable();
        EnhancedTouch.Touch.onFingerDown -= OnFingerDown;
    }

    private void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        if (!_planeSelectionDone)
        {
            _backgroundImage.color = new Color(0, 255, 0, 0.35f);
            _text.text = SELECT_PLANE;
        }
    }

    private void OnFingerDown(EnhancedTouch.Finger finger)
    {
        if (finger.index != 0)
            return;

        if (_raycastManager.Raycast(finger.currentTouch.screenPosition, _hits, TrackableType.PlaneWithinPolygon) && !_planeSelectionDone)
        {
            _planeManager.requestedDetectionMode = PlaneDetectionMode.None;
            ARPlane hitPlane = _planeManager.GetPlane(_hits[0].trackableId);

            foreach (ARPlane plane in _planeManager.trackables)
            {
                if (plane != hitPlane)
                    plane.gameObject.SetActive(false);
                // else
                //     plane.gameObject.GetComponent<ARPlaneMeshVisualizer>().enabled = false;
            }

            _planeSelectionDone = true;
            _backgroundImage.color = Color.clear;
            _text.gameObject.SetActive(false);
            _startButton.gameObject.SetActive(true);

            InstantiateTarget(hitPlane);
        }
    }

    private void InstantiateTarget(ARPlane plane)
    {
        for (int i = 0; i < _numberTarget; i++)
        {
            Vector2 randomPosition = GetRandomPointOnPlane(plane);
            Vector3 spawnPosition = new Vector3(randomPosition.x, plane.transform.position.y, randomPosition.y);

            GameObject obj = Instantiate(_prefab, spawnPosition, Quaternion.identity);

            obj.GetComponent<TargetMovement>().PlaneBoundary = plane.boundary.ToArray();
        }
    }

    private Vector2 GetRandomPointOnPlane(ARPlane plane)
    {
        Vector2 min = new Vector2(plane.center.x - plane.extents.x / 2, plane.center.z - plane.extents.y / 2);
        Vector2 max = new Vector2(plane.center.x + plane.extents.x / 2, plane.center.z + plane.extents.y / 2);

        return new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));
    }
}
