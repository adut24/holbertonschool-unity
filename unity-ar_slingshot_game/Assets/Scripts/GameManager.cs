using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Manages the different states of the game.
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Canvas _gameCanvas;
    [SerializeField]
    private GameObject _ammo;
    [SerializeField]
    private int _numberAmmo;
    [SerializeField]
    private Button _startButton;
    [SerializeField]
    private Image _backgroundImage;
    [SerializeField]
    private Image _backgroundImage2;
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    [SerializeField]
    private TextMeshProUGUI _ammoLeft;
    private bool _isGameStarted = false;
    public TargetMovement[] Targets { get; set; }
    public int NumberAmmo 
    { 
        get => _numberAmmo;
        set
        {
            if (value < 0) 
                value = 1;
            _numberAmmo = value;
        }
    }

    private void Update()
    {
        if (_isGameStarted)
            _scoreText.text = "0";
    }

    /// <summary>
    /// Starts the game.
    /// </summary>
    public void StartGame()
    {
        _startButton.gameObject.SetActive(false);
        _backgroundImage.gameObject.SetActive(true);
        _backgroundImage2.gameObject.SetActive(true);

        Vector3 position = Camera.main.ScreenToWorldPoint(Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0))) + Camera.main.transform.forward * 2f;
        Instantiate(_ammo, position, Quaternion.identity);

        foreach (TargetMovement target in Targets)
            target.enabled = true;

        _ammoLeft.text = NumberAmmo.ToString();
    }

    /// <summary>
    /// Restarts the game.
    /// </summary>
    public void RestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    /// <summary>
    /// Quit the application.
    /// </summary>
    public void QuitGame() => Application.Quit();
}
