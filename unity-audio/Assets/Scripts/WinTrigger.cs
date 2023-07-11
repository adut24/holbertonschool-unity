using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public Timer timer;
    public Text textTimer;
    public AudioSource audioSource;
    public AudioClip winSting;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Player")
        {
            audioSource.clip = winSting;
            audioSource.loop = false;
            audioSource.Play();
            Timer.Win();
        }
    }
}
