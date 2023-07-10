using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Toggle invertYToggle;
    private CameraController cameraController;

    private void Start()
    {
        cameraController = FindObjectOfType<CameraController>();
        invertYToggle.isOn = cameraController.isInverted;
    }

    public void Apply()
    {
        cameraController.isInverted = invertYToggle.isOn;
        Back();
    }

    /// <summary>
    /// Loads the previous scene.
    /// </summary>
    public void Back()
    {
        foreach (GameObject obj in SceneHistory.sceneObjects)
        {
            if (obj.name != "WinCanvas")
                obj.SetActive(true);
        }

        SceneManager.UnloadSceneAsync("Options");
    }
}
