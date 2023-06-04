using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public Canvas winCanvas;
    public Canvas timerCanvas;
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

    /// <summary>
    /// Displays the win message window and menu.
    /// </summary>
    public void Win()
    {
        winCanvas.gameObject.SetActive(true);
        timerCanvas.gameObject.SetActive(false);
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().enabled = false;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraController>().enabled = false;
        GameObject.Find("WinCanvas/FinalTime").GetComponent<Text>().text = timerText.text;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "WinFlag")
            Win();
    }
}
