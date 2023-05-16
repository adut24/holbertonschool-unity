using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private double second;
    private int minute;
    private string timerString;
    private string secondString;

    private void Update()
    {
        second = System.Math.Round(second + Time.deltaTime, 2);
        if (second > 60)
        {
            minute++;
            second %= 60;
        }
        secondString = second < 10 ? ("0" + second) : second.ToString();
        timerString = minute + ":" + secondString;
        timerText.text = timerString;
    }
}

