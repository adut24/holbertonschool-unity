using UnityEngine;

public class Block : MonoBehaviour
{
    public bool isBreakable;
    public bool containsCoins;
    public int coinsNumber;

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
