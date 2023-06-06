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
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// Loads the next scene.
    /// </summary>
    public void Next() => SceneManager.LoadScene(GetNextScene(SceneManager.GetActiveScene().name));

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
