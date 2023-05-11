using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Represents the main menu and its behavior.
/// </summary>
public class MainMenu : MonoBehaviour
{
	/// <summary>
	/// Represents the color applied to the trap.
	/// </summary>
	public Material trapMat;
	/// <summary>
	/// Represents the color applied to the goal.
	/// </summary>
	public Material goalMat;
	/// <summary>
	/// Represents the toggle to go from normal mode to colorblind.
	/// </summary>
	public Toggle colorblindMode;

	/// <summary>
	/// Launches the maze game.
	/// </summary>
	public void PlayMaze()
	{
		if (colorblindMode.isOn)
		{
			trapMat.color = new Color32(255, 112, 0, 1);
			goalMat.color = Color.blue;
		}
		else
		{
			trapMat.color = Color.red;
			goalMat.color = Color.green;
		}
		SceneManager.LoadScene("maze");
	}

	/// <summary>
	/// Quits the application.
	/// </summary>
	public void QuitMaze()
	{
		Debug.Log("Quit Game");
		Application.Quit();
	}
}
