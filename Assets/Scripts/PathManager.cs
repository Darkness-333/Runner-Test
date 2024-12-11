using UnityEngine;

public class PathManager : MonoBehaviour {
    [SerializeField] private Transform[] platforms;
    public Transform finish;
    private int currentPlatform = 0;

    public bool platformsEnd => platforms.Length < currentPlatform + 1;

    private void Start() {
        finish.position -= finish.position.y * Vector3.up;
    }

    public Vector3 GetPlatformPosition() {
        print(currentPlatform);
        Vector3 position = platforms[currentPlatform].position;
        position.y = 0;
        currentPlatform++;
        return position;
    }

}