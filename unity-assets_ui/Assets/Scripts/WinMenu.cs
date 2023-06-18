using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    /// <summary>
    /// Opens the main menu.
    /// </summary>
    public void MainMenu()
    {
        SceneHistory.sceneVisited.Add("MainMenu");
        Destroy(GameObject.Find("MenuEvent"));
        Destroy(GameObject.FindWithTag("MainCamera"));
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// Loads the next scene.
    /// </summary>
    public void Next()
    {
        SceneManager.LoadScene(GetNextScene(SceneManager.GetActiveScene().name));
        PlayerController playerController = FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            playerController.enabled = false;
            playerController.enabled = true;
        }
        CameraController cameraController = FindObjectOfType<CameraController>();
        if (cameraController != null)
        {
            cameraController.enabled = false;
            cameraController.enabled = true;
        }
    }

    private string GetNextScene(string currentScene)
    {
        switch (currentScene)
        {
            case "Level01":
                SceneHistory.sceneVisited.Add("Level02");
                return "Level02";
            case "Level02":
                SceneHistory.sceneVisited.Add("Level03");
                return "Level03";
        }
        return null;
    }
}
