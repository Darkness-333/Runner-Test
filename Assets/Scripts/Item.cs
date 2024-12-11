using UnityEngine;

public class Item : MonoBehaviour {
    [SerializeField] private int points;  

    private void OnTriggerEnter(Collider other) {
        print("trigger enter");
        if (other.CompareTag("Player")) {
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();

            scoreManager.ModifyScore(points);

            Destroy(gameObject);  
        }
    }
}
