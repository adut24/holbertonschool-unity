using System.Linq;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public GameObject timerCanvas;
    public PlayerController playerController;
    private GameObject mainCamera;

    void Awake()
    {
        mainCamera = FindObjectsOfType<Camera>(true).First(cam => cam.tag == "MainCamera").gameObject;
        mainCamera.SetActive(false);
    }

    private void GameStart()
    {
        mainCamera.SetActive(true);
        playerController.enabled = true;
        timerCanvas.SetActive(true);
        gameObject.SetActive(false);
    }
}
