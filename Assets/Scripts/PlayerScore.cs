using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Transform playerPos;
    private float maxPlayerY;
    private float lastPosition = 0f;
    private float scoreMultiplyer = 10f;
    private float scoreBonus = 1f;
    float score = 0f;

    void Start()
    {
        lastPosition = playerPos.position.y;
        maxPlayerY = lastPosition;
    }


    // Update is called once per frame
    void Update()
    {
        if (playerPos.position.y > maxPlayerY)
        {
            maxPlayerY = playerPos.position.y;
            score += (maxPlayerY - lastPosition) * scoreMultiplyer * scoreBonus;
            scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
            lastPosition = maxPlayerY;
        }
    }

    public void ApplyScoreBonus(float bonus)
    {
        scoreBonus = bonus;
        StartCoroutine(scoreBonusTimer(5f)); // Bonus lasts for 5 seconds

    }

    IEnumerator scoreBonusTimer(float duration)
    {
        yield return new WaitForSeconds(duration);
        scoreBonus = 1f; // Reset the score bonus after the duration
        Debug.Log("Score bonus expired");
    }

    public void AddScore(float amount)
    {
        score += amount * scoreBonus;
        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
    }
}