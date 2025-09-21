using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    public Transform background; // your Quad

    [Header("Settings")]
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    private float camHalfHeight, camHalfWidth;
    private float minX, maxX, minY, maxY;

    void Start()
    {
        Camera cam = Camera.main;

        // Camera view size in world units
        camHalfHeight = cam.orthographicSize;
        camHalfWidth = camHalfHeight * cam.aspect;

        // Background world size (from Quad scale)
        float bgWidth = background.localScale.x;
        float bgHeight = background.localScale.y;

        // Clamp limits (edges of the Quad minus half camera size)
        minX = background.position.x - bgWidth / 2 + camHalfWidth;
        maxX = background.position.x + bgWidth / 2 - camHalfWidth;
        minY = background.position.y - bgHeight / 2 + camHalfHeight;
        maxY = background.position.y + bgHeight / 2 - camHalfHeight;
    }

    void LateUpdate()
    {
        if (player == null) return;

        // Smooth follow
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Clamp inside background
        float clampX = Mathf.Clamp(smoothedPosition.x, minX, maxX);
        float clampY = Mathf.Clamp(smoothedPosition.y, minY, maxY);

        transform.position = new Vector3(clampX, clampY, -10f);
    }
}
