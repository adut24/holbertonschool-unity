using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text collectedCoinsText;
    public Rigidbody2D rb;
    public int collectedCoins;
    public int lives;
    public int score;

    private void Update()
    {
        if (collectedCoins == 100)
            IncreaseNumberLife();
    }

    private void IncreaseNumberLife()
    {
        lives++;
        collectedCoins = 0;
    }
}
