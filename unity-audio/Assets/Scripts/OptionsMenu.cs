using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Toggle invertYToggle;
    public Slider bgmSlider;
    public Slider sfxSlider;
    public AudioMixer mixer;
    private CameraController cameraController;

    private void Start()
    {
        cameraController = FindObjectOfType<CameraController>();
        invertYToggle.isOn = cameraController.isInverted;
        bgmSlider.value = PlayerPrefs.GetFloat("bgmVol", 1f);
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVol", 1f);
        SetLevel();
    }

    /// <summary>
    /// Applies the current settings.
    /// </summary>
    public void Apply()
    {
        cameraController.isInverted = invertYToggle.isOn;
        PlayerPrefs.SetInt("invertedY", Convert.ToInt32(invertYToggle.isOn));
        PlayerPrefs.SetFloat("bgmVol", bgmSlider.value);
        PlayerPrefs.SetFloat("sfxVol", sfxSlider.value);
        PlayerPrefs.Save();
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

    /// <summary>
    /// Sets the volume level.
    /// </summary>
    public void SetLevel()
    {
        float bgmValue = bgmSlider.value;
        mixer.SetFloat("bgmVol", bgmValue != 0 ? 20 * Mathf.Log10(bgmValue) : -80f);
        float sfxValue = sfxSlider.value;
        float volumeModifier = sfxValue != 0 ? (20 * Mathf.Log10(sfxValue)) : -80f;
        mixer.SetFloat("runningVol", volumeModifier - 20);
        mixer.SetFloat("landingVol", volumeModifier + 2);
        mixer.SetFloat("ambVol", volumeModifier + 5);
    }
}
