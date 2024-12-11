using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI statusText;
    [SerializeField] private GameObject player;


    private int score = 0;
    private int maxScore = 100;

    void Start() {
        UpdateScore();
    }

    public void MultiplyScore(int coeff) {
        score *= coeff;
        UpdateParametres();
    }

    public void ModifyScore(int points) {
        score += points;
        UpdateParametres();
    }

    private void UpdateParametres() {
        score = Mathf.Clamp(score, 0, maxScore);

        UpdateScore();

        if (score < 30) {
            ShowVisual(0);
            SetStatus(0);
        }
        else if (score < 60) {
            ShowVisual(1);
            SetStatus(1);

        }
        else {
            ShowVisual(2);
            SetStatus(2);

        }
    }

    private void SetStatus(int status) {
        if (status == 0) {
            statusText.SetText("Бедный");
            statusText.color = Color.red;
        }
        else if (status == 1) {
            statusText.SetText("Состоятельный");
            statusText.color = Color.yellow;

        }
        else {
            statusText.SetText("Богатый");
            statusText.color = Color.green;

        }
    }

    private void ShowVisual(int visual) {
        for (int i = 0; i < 3; i++) {
            if (i == visual) {
                player.transform.GetChild(i).gameObject.SetActive(true);

            }
            else {
                player.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    private void UpdateScore() {
        scoreText.text = "Score: " + score.ToString();
    }

    public int GetScore() {
        return score;
    }
}
