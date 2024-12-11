using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI hintText;
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private int winScore = 50;
    [SerializeField] private static int currentLevel = 1;

    private bool gameStarted = false;
    private bool gameFinished = false;
    private PlayerMovement player;

    private float normalSpeed;

    void Start() {
        player = FindObjectOfType<PlayerMovement>();
        normalSpeed = player.speed;
        player.speed = 0;

        hintText.gameObject.SetActive(true);
        resultText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        nextLevelButton.gameObject.SetActive(false);

        levelText.text = "Level " + currentLevel;
    }

    void Update() {
        if (!gameStarted && Input.GetMouseButtonDown(0)) {
            StartGame();
        }
    }

    void StartGame() {
        gameStarted = true;
        hintText.gameObject.SetActive(false);
        player.speed = normalSpeed;
    }

    public void FinishGame() {
        if (gameFinished) return;
        gameFinished = true;
        player.speed = normalSpeed;

        resultText.gameObject.SetActive(true);

        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        resultText.text = scoreManager.GetScore() > winScore ? "Победа!" : "Проиграл!";
        restartButton.gameObject.SetActive(true);
        nextLevelButton.gameObject.SetActive(true);
    }

    public void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel() {
        currentLevel++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
