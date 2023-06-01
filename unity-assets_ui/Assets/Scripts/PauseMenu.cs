using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused;
    public GameObject pauseMenu;
    public Timer timer;
    public CameraController cameraController;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
                Pause();
            else
                Resume();
        }
    }

    /// <summary>
    /// Pauses the game.
    /// </summary>
    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        timer.enabled = false;
        cameraController.enabled = false;
    }

    /// <summary>
    /// Resumes the game.
    /// </summary>
    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1;
        pauseMenu.gameObject.SetActive(false);
        timer.enabled = true;
        cameraController.enabled = true;
    }

    /// <summary>
    /// Restarts the current level.
    /// </summary>
    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    /// <summary>
    /// Opens the main menu.
    /// </summary>
    public void MainMenu()
    {
        SceneHistory.sceneVisited.Add("MainMenu");
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// Opens the options menu.
    /// </summary>
    public void Options()
    {
        SceneHistory.sceneVisited.Add("Options");
        SceneHistory.sceneObjects.Clear();
        SceneHistory.sceneObjects = SceneManager.GetActiveScene().GetRootGameObjects().ToList();
        foreach (GameObject obj in SceneHistory.sceneObjects)
            obj.SetActive(false);
        SceneManager.LoadScene("Options", LoadSceneMode.Additive);
    }
}
