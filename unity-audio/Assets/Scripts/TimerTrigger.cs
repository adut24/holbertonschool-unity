using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    private void OnCollisionExit(Collision collision)
    {
        collision.gameObject.GetComponent<Timer>().enabled = true;
        GetComponent<BoxCollider>().enabled = false;
    }
}
