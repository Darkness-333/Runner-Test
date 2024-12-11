using UnityEngine;

public class DoorRotator : MonoBehaviour {
    [SerializeField] private Transform door1; 
    [SerializeField] private Transform door2; 
    [SerializeField] private float rotationAngle = 90f; 
    [SerializeField] private float rotationSpeed = 90f; 

    private bool isRotating = false;
    private float rotatedAngle = 0f;

    private void Update() {
        if (isRotating) {
            float step = rotationSpeed * Time.deltaTime;

            step = Mathf.Min(step, rotationAngle - rotatedAngle);

            door1.Rotate(Vector3.up, step);
            door2.Rotate(-Vector3.up, step);

            rotatedAngle += step;

            if (rotatedAngle >= rotationAngle) {
                isRotating = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && !isRotating) {
            isRotating = true; 
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            scoreManager.MultiplyScore(2); 
        }
    }
}
