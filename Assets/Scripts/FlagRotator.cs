using UnityEngine;

public class FlagRotator : MonoBehaviour {
    [SerializeField] private Transform flag1;
    [SerializeField] private Transform flag2; 
    [SerializeField] private float rotationAngle = 90f; 
    [SerializeField] private float rotationSpeed = 90f; 

    private bool isRotating = false;
    private float rotatedAngle = 0f;

    private void Update() {
        if (isRotating) {
            float step = rotationSpeed * Time.deltaTime;

            step = Mathf.Min(step, rotationAngle - rotatedAngle);

            flag1.Rotate(-Vector3.forward, step);
            flag2.Rotate(-Vector3.forward, step);

            rotatedAngle += step;

            if (rotatedAngle >= rotationAngle) {
                isRotating = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && !isRotating) {
            isRotating = true; 
        }
    }
}
