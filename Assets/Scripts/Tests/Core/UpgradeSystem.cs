using UnityEngine;

public enum UpgradeType
{
    Jump,
    Speed,
    CoyoteTime
}

public class UpgradeSystem : MonoBehaviour
{
    public int Points { get; private set; }

    public float JumpForce { get; private set; } = 5f;
    public float Speed { get; private set; } = 5f;
    public float CoyoteTime { get; private set; } = 0.2f;

    public UpgradeSystem(int initialPoints)
    {
        Points = initialPoints < 0 ? 0 : initialPoints;
    }

    public bool TryUpgrade(UpgradeType upgradeType)
    {
        int cost = GetCost(upgradeType);

        if (cost < 0 || Points < cost)
        {
            Debug.Log("Invalid upgrade type.");
            return false;
        }

        if (IsAtMaxLevel(upgradeType))
        {
            Debug.Log($"{upgradeType} is already at max level.");
            return false;
        }
        Points -= cost;
        ApplyUpgrade(upgradeType);
        Debug.Log($"Upgraded {upgradeType}. Remaining points: {Points}");
        return true;
    }

    private int GetCost(UpgradeType type)
    {
        switch (type)
        {
            case UpgradeType.Jump: return 8;
            case UpgradeType.Speed: return 5;
            case UpgradeType.CoyoteTime: return 3;
            default: return -1;
        }
    }


    private bool IsAtMaxLevel(UpgradeType type)
    {
        switch (type)
        {
            case UpgradeType.Jump: return JumpForce >= 10f;
            case UpgradeType.Speed: return Speed >= 10f;
            case UpgradeType.CoyoteTime: return CoyoteTime >= 0.5f;
            default: return true;
        }
    }

    private void ApplyUpgrade(UpgradeType type)
    {
        switch (type)
        {
            case UpgradeType.Jump:
                JumpForce = UnityEngine.Mathf.Min(JumpForce + 1f, 10f); // Increase jump force
                break;
            case UpgradeType.Speed:
                Speed = UnityEngine.Mathf.Min(Speed + 1f, 10f); // Increase speed
                break;
            case UpgradeType.CoyoteTime:
                CoyoteTime = UnityEngine.Mathf.Min(CoyoteTime + 0.05f, 0.5f); // Increase coyote time
                break;
        }
    }

    public void AddPoints(int points)
    {
        if (points < 0)
        {
            Debug.Log("Cannot add negative points.");
            return;
        }
        Points += points;
        Debug.Log($"Added {points} points. Total points: {Points}");
    }
}
