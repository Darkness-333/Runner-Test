using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private PathManager pathManager;

    [SerializeField] public float speed = 5;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float sensitivity = 0.01f;
    [SerializeField] private float movementLimit = 2.8f;

    private Vector3 direction;
    private Vector3 prevPosition;
    private Vector3 targetPosition;
    private Vector3 projectionPoint;

    private GameManager gameManager;

    private void Start() {
        prevPosition = transform.position;
        prevPosition.y = 0;

        targetPosition = pathManager.GetPlatformPosition();

        direction = targetPosition - prevPosition;
        direction.y = 0;

        transform.rotation = Quaternion.LookRotation(direction);

        lastMousePosition = Input.mousePosition;

        gameManager = FindObjectOfType<GameManager>();
    }


    private void Update() {

        MouseMove();

        transform.position += transform.forward * speed * Time.deltaTime;

        Vector3 AP = transform.position - prevPosition;
        float projectionLength = Vector3.Dot(AP, direction) / direction.sqrMagnitude;
        projectionPoint = prevPosition + projectionLength * direction;

        float leftDistance = Vector3.Distance(targetPosition, projectionPoint);

        if (leftDistance < 0.35f) {
            if (targetPosition == pathManager.finish.position) {
                speed = 0;
                gameManager.FinishGame();
                return;
            }

            if (pathManager.platformsEnd) {
                targetPosition = pathManager.finish.position;
            }
            else {
                prevPosition = targetPosition;
                targetPosition = pathManager.GetPlatformPosition();
            }

            direction = targetPosition - prevPosition;
            direction.y = 0;
        }

        if (direction != Vector3.zero) {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }


    private Vector3 lastMousePosition;

    private void MouseMove() {

        float deltaX = Input.mousePosition.x - lastMousePosition.x;

        float movement = deltaX * sensitivity;

        Vector3 currentPosition = transform.position;


        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.z)) {
            currentPosition.z += movement;
            currentPosition.z = Mathf.Clamp(currentPosition.z, prevPosition.z - movementLimit, prevPosition.z + movementLimit);
        }
        else {
            currentPosition.x += movement;
            currentPosition.x = Mathf.Clamp(currentPosition.x, prevPosition.x - movementLimit, prevPosition.x + movementLimit);
        }

        transform.position = currentPosition;

        lastMousePosition = Input.mousePosition;
    }

}




