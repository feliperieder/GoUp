using UnityEngine;

public class PlayerDoubleJump : MonoBehaviour
{
    public int ExtraJumps { get; private set; } // Remaining jumps available
    public int maxExtraJumps { get; private set; } = 5; // Maximum extra jumps allowed

    public PlayerDoubleJump(int initialExtraJumps)
    {
        ExtraJumps = initialExtraJumps < 0 ? 0 : initialExtraJumps;
        if (ExtraJumps > maxExtraJumps)
        {
            ExtraJumps = maxExtraJumps; // Cap the initial extra jumps to the maximum allowed
        }
    }

    public void AddExtraJump(int amount)
    {
        ExtraJumps += amount;
        if (ExtraJumps > maxExtraJumps)
        {
            ExtraJumps = maxExtraJumps; // Cap the extra jumps to the maximum allowed
        }
    }

    public void RemoveExtraJump(int amount)
    {
        ExtraJumps -= amount;
        if (ExtraJumps < 0)
        {
            ExtraJumps  = 0; // Ensure extra jumps do not go below zero
        }
    }
}
