using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
    }
}
