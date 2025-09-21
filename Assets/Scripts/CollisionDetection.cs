using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public float knockbackForce = 5f;
    public float knockbackUpward = 2f;  // vertical strength (optional)
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            UIManager uiManager = FindObjectOfType<UIManager>();
            if (uiManager != null)
            {
                uiManager.ShowGameOver();
            }
        }

        if (collision.collider.tag == "Object")
        {
            rb.velocity = Vector2.zero;
            Vector2 knockback = new Vector2(-knockbackForce, knockbackUpward);
            rb.AddForce(knockback, ForceMode2D.Impulse);
        }
    }
}
