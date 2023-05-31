using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public Timer timer;
    public Text textTimer;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Player")
        {
            timer.enabled = false;
            textTimer.fontSize = 60;
            textTimer.color = Color.green;
        }
    }
}
