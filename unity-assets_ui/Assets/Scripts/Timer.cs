using System.Globalization;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private static Text timerText;
    private static Canvas winCanvas;
    private static Canvas timerCanvas;
    private float second;
    private int minute;
    private string secondString;

    private void Start()
    {
        timerCanvas = GameObject.Find("TimerCanvas").GetComponent<Canvas>();
        timerText = timerCanvas.GetComponentInChildren<Text>();
        winCanvas = FindObjectsOfType<Canvas>(true).First(canvas => canvas.gameObject.name == "WinCanvas");
    }

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

    /// <summary>
    /// Displays the win message window and menu.
    /// </summary>
    public static void Win()
    {
        winCanvas.gameObject.SetActive(true);
        timerCanvas.gameObject.SetActive(false);
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().enabled = false;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraController>().enabled = false;
        GameObject.Find("WinCanvas/FinalTime").GetComponent<Text>().text = timerText.text;
    }
}
