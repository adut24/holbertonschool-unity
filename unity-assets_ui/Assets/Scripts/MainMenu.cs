using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static List<string> sceneHistory = new();

    private void Awake() => DontDestroyOnLoad(gameObject);

    private void Start() => sceneHistory.Add("MainMenu");

    /// <summary>
    /// Loads the level selected with <paramref name="level"/>.
    /// </summary>
    /// <param name="level">Level to load.</param>
    public void LevelSelect(int level)
    {
        sceneHistory.Add("Level0" + level);
        SceneManager.LoadScene("Level0" + level);
    }

    /// <summary>
    /// Loads the options menu.
    /// </summary>
    public void Options()
    {
        sceneHistory.Add("Options");
        SceneManager.LoadScene("Options");
    }

    /// <summary>
    /// Exits the game.
    /// </summary>
    public void Exit()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
}
