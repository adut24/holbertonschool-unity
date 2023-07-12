using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioMixer mixer;
    public CameraController cam;

    private void Start()
    {
        ApplyStoredParameter();
        SceneHistory.sceneVisited.Add("MainMenu");
    }

    private void ApplyStoredParameter()
    {
        float storedBGMVolume = PlayerPrefs.GetFloat("bgmVol", 1f);
        mixer.SetFloat("bgmVol", storedBGMVolume != 0 ? 20 * Mathf.Log10(storedBGMVolume) : -80f);
        float storedSFXVolume = PlayerPrefs.GetFloat("sfxVol", 1f);
        float volumeModifier = storedSFXVolume != 0 ? (20 * Mathf.Log10(storedSFXVolume)) : -80f;
        mixer.SetFloat("runningVol", volumeModifier - 20);
        mixer.SetFloat("landingVol", volumeModifier + 2);
        mixer.SetFloat("ambVol", volumeModifier + 5);
        cam.isInverted = Convert.ToBoolean(PlayerPrefs.GetInt("invertedY"));
    }

    /// <summary>
    /// Loads the level selected with <paramref name="level"/>.
    /// </summary>
    /// <param name="level">Level to load.</param>
    public void LevelSelect(int level)
    {
        SceneHistory.sceneVisited.Add("Level0" + level);
        SceneManager.LoadScene("Level0" + level);
        Time.timeScale = 1f;
        PlayerController playerController = FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            playerController.enabled = false;
            playerController.enabled = true;
        }
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
        {
            if (obj.name != "Wallpaper")
                obj.SetActive(false);
        }

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
