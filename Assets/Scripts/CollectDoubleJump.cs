using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectDoubleJump : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Add bonus points to the player's score
            collision.gameObject.GetComponent<PlayerScript>().AddDoubleJump(); // Example multiplier value
            // Destroy the bonus pickup object
            Destroy(gameObject);
        }
    }
}
