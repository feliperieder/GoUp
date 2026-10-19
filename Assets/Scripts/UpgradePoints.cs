using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class UpgradePoints : MonoBehaviour
{
    [SerializeField] private UpgradeManager upgradeManager;
    [SerializeField] private TextMeshProUGUI pointsText;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            upgradeManager.AddPoints(1);
            pointsText.text = "Pontros de Upgrade: " + Mathf.FloorToInt(upgradeManager.GetCurrentPoints()).ToString();
            Destroy(gameObject);
        }
    }
}
