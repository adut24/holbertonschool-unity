using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOpener : MonoBehaviour
{
	public void LoadMenu()
	{
		SceneManager.LoadScene("menu");
	}
}
