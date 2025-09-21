using UnityEngine;

public class ScorableObject : MonoBehaviour
{
    private bool scored = false; // to avoid counting multiple times

    void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (!scored && player != null)
        {
            if (transform.position.x < player.transform.position.x)
            {
                scored = true; // mark as counted
                FindObjectOfType<UIManager>().UpdateScore(1);
            }
        }
    }
}
