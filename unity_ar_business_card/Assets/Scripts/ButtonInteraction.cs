using UnityEngine;

/// <summary>
/// Represents the action taken when a button is pressed.
/// </summary>
public class ButtonInteraction : MonoBehaviour
{
    /// <summary>
    /// Opens the link in the browser according to the button pressed.
    /// </summary>
    /// <param name="link">Link to send as an URL</param>
    public void OpenLink(string link) => Application.OpenURL(gameObject.name == "MailButton" ? "mailto:" + link : link);
}
