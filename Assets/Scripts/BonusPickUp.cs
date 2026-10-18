


using TMPro;
using UnityEngine;

public class BonusPickUp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    PlayerScore scoreManager;
    [SerializeField] private float scoreBonus = 50f;
    [SerializeField] private TextMeshProUGUI scoreBonusText;


    private void Start()
    {
        scoreManager = FindObjectOfType<PlayerScore>();
        if (scoreBonusText != null)
        {
            scoreBonusText.text = "+" + scoreBonus.ToString();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Add bonus points to the player's score
            scoreManager.AddScore(scoreBonus);
            // Destroy the bonus pickup object
            Destroy(gameObject);
        }
    }
}

