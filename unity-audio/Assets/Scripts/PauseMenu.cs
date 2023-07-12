using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public Timer timer;
    public AudioMixerSnapshot paused;
    public AudioMixerSnapshot unpaused;
    private bool isPaused;
    private CameraController cameraController;

    private void Start() => cameraController = GameObject.FindWithTag("MainCamera").GetComponent<CameraController>();

    private void Update()
    {
        if (!cameraController)
            Start();
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
        paused.TransitionTo(.01f);
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
        unpaused.TransitionTo(.01f);
    }

    /// <summary>
    /// Restarts the current level.
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
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
    /// Opens the options menu.
    /// </summary>
    public void Options()
    {
        SceneHistory.sceneVisited.Add("Options");
        SceneHistory.sceneObjects.Clear();
        SceneHistory.sceneObjects = SceneManager.GetActiveScene().GetRootGameObjects().ToList();
        foreach (GameObject obj in SceneHistory.sceneObjects)
        {
            if (obj.tag != "BGM")
                obj.SetActive(false);
        }

        SceneManager.LoadScene("Options", LoadSceneMode.Additive);
    }
}
