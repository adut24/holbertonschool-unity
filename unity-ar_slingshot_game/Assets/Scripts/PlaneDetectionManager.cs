using System.Collections.Generic;
using TMPro;
using UnityEngine;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

/// <summary>
/// 
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

        if (_raycastManager.Raycast(finger.currentTouch.screenPosition, _hits, TrackableType.PlaneWithinPolygon))
        {
            ARPlane hitPlane = _hits[0].trackable as ARPlane;

            _planeManager.requestedDetectionMode = PlaneDetectionMode.None;

            foreach (var plane in _planeManager.trackables)
            {
                if (plane != hitPlane)
                    plane.gameObject.SetActive(false);
                else
                    plane.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
            _planeSelectionDone = true;

            _backgroundImage.color = Color.clear;
            _text.gameObject.SetActive(false);
            _startButton.gameObject.SetActive(true);
        }
    }
}
