using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float second;
    private int minute;
    private string secondString;

    private void Update()
    {
        second += Time.deltaTime;

        if (second > 60)
        {
            minute++;
            second %= 60;
        } 
        secondString = second.ToString("f2", new CultureInfo("en-US"));
        secondString = second < 10 ? ("0" + secondString) : secondString;
        timerText.text = minute + ":" + secondString;
    }
}

