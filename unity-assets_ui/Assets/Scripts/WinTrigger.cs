using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public Timer timer;
    public Text textTimer;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Player")
            Timer.Win();
    }
}
