using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start() => SceneHistory.sceneVisited.Add("MainMenu");

    /// <summary>
    /// Loads the level selected with <paramref name="level"/>.
    /// </summary>
    /// <param name="level">Level to load.</param>
    public void LevelSelect(int level)
    {
        SceneHistory.sceneVisited.Add("Level0" + level);
        SceneManager.LoadScene("Level0" + level);
    }

    /// <summary>
    /// Loads the options menu.
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

    /// <summary>
    /// Exits the game.
    /// </summary>
    public void Exit()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
}
