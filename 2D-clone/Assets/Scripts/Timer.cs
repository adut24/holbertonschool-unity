using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int remainingTime;
    public Text timerText;

    private void Update()
    {
        remainingTime = Mathf.FloorToInt(remainingTime - Time.deltaTime);
        timerText.text = remainingTime.ToString();
    }
}
