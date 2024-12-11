using UnityEngine;

public class Gate : MonoBehaviour {
    public int scoreChange = 10; 

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            scoreManager.ModifyScore(scoreChange);
        }
    }
}
