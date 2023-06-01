using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    /// <summary>
    /// Loads the previous scene.
    /// </summary>
    public void Back()
    {
        foreach (GameObject obj in SceneHistory.sceneObjects)
            obj.SetActive(true);
        SceneManager.UnloadSceneAsync("Options");
    }
}
