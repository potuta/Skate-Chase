using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundary : MonoBehaviour
{
    public Transform background;
    private Camera cam;
    private float halfWidth, halfHeight;

    void Start()
    {
        cam = Camera.main;

        // Assuming the player has a SpriteRenderer
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            halfWidth = sr.bounds.size.x / 2f;
            halfHeight = sr.bounds.size.y / 2f;
        }
        else
        {
            halfWidth = 0.5f;
            halfHeight = 0.5f;
        }
    }

    void LateUpdate()
    {
        Vector3 pos = transform.position;

        float bgHalfWidth = background.localScale.x / 2f;
        float bgHalfHeight = background.localScale.y / 2f;

        float minX = background.position.x - bgHalfWidth + halfWidth;
        float maxX = background.position.x + bgHalfWidth - halfWidth;
        float minY = background.position.y - bgHalfHeight + halfHeight;
        float maxY = background.position.y + bgHalfHeight - halfHeight;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }
}
