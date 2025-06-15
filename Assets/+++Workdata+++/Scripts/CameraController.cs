
using UnityEngine;


public class CameraController : MonoBehaviour
{
    public Transform ziel;
    public BoxCollider2D grenzen;
    public float kameraSpeed = 5f;

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void LateUpdate()
    {
        Vector3 zielPos = new Vector3(ziel.position.x, ziel.position.y, -10f);

        // Kamera Hälften berechnen
        float halfHeight = cam.orthographicSize;
        float halfWidth = halfHeight * cam.aspect;

        Bounds bounds = grenzen.bounds;

        // Clamping = Kamera bleibt innerhalb des Colliders
        float clampX = Mathf.Clamp(zielPos.x, bounds.min.x + halfWidth, bounds.max.x - halfWidth);
        float clampY = Mathf.Clamp(zielPos.y, bounds.min.y + halfHeight, bounds.max.y - halfHeight);

        Vector3 begrenzt = new Vector3(clampX, clampY, zielPos.z);

        // Kamera folgt sanft
        transform.position = Vector3.Lerp(transform.position, begrenzt, kameraSpeed * Time.deltaTime);
    }
}
