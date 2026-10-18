using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreMultiplier : MonoBehaviour
{
    PlayerScore scoreManager;
    [SerializeField] private TextMeshProUGUI scoreBonusText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreManager = FindObjectOfType<PlayerScore>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Add bonus points to the player's score
            scoreManager.ApplyScoreBonus(2f); // Example multiplier value
            // Destroy the bonus pickup object
            Destroy(gameObject);
        }
    }
}
