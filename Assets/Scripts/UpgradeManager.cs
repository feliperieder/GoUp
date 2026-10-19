using UnityEngine;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private PlayerScript player;
    [SerializeField] private TextMeshProUGUI pointsText;    

    private UpgradeSystem upgrades;

    private void Awake()
    {
        upgrades = new UpgradeSystem(0);
    }

    public void BuyJumpUpgrade()
    {
        if (upgrades.TryUpgrade(UpgradeType.Jump))
        {
            ApplyCurrentStats();
            pointsText.text = "Pontos de Upgrade: " + Mathf.FloorToInt(upgrades.Points).ToString();
        }
    }

    public void BuySpeedUpgrade()
    {
        if (upgrades.TryUpgrade(UpgradeType.Speed))
        {
            ApplyCurrentStats();
            pointsText.text = "Pontos de Upgrade: " + Mathf.FloorToInt(upgrades.Points).ToString();
        }
    }

    public void BuyCoyoteTimeUpgrade()
    {
        if (upgrades.TryUpgrade(UpgradeType.CoyoteTime))
        {
            ApplyCurrentStats();
            pointsText.text = "Pontos de Upgrade: " + Mathf.FloorToInt(upgrades.Points).ToString();
        }   
    }

    private void ApplyCurrentStats()
    {
        if (player != null) { 
            player.ApplyUpgrades(upgrades.Speed, upgrades.JumpForce, upgrades.CoyoteTime);
        }
    }

    public int GetCurrentPoints()
    {
        return upgrades.Points;
    }

    public void AddPoints(int points)
    {
        upgrades.AddPoints(points);
    }

}
