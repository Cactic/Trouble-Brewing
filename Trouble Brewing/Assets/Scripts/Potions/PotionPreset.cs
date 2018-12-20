/// <summary> An immutable collection of stats.
/// <para> They cannot be assigned to game objects, use StatsCollection instead.</para></summary>
public struct PotionPreset
{
    public string PotionName;
    public float Health;
    public float MovementSpeed;
    public float AttackPower;
    public int Defence;
    public int Piercing;
    public float AttackSpeed;
    public ElementTypes ElementTyping;
    
    /// <summary> Creates a new PotionPreset.</summary>
    /// <param name="potionName"> Name for the potion.</param>
    /// <param name="health"> Health boost from potion.</param>
    /// <param name="movementSpeed"> Movement speed boost from potion.</param>
    /// <param name="attackPower"> Attack power boost from potion.</param>
    /// <param name="defence"> Defence boost from potion.</param>
    /// <param name="piercing"> Piercing boost from potion.</param>
    /// <param name="attackSpeed"> Attack speed boost from potion.</param>
    /// <param name="elementTyping"> Element typing from potion.</param>
    public PotionPreset(string potionName,float health, float movementSpeed, float attackPower, int defence, int piercing, float attackSpeed, ElementTypes elementTyping)
    {
        PotionName = potionName;
        Health = health;
        MovementSpeed = movementSpeed;
        AttackPower = attackPower;
        Defence = defence;
        Piercing = piercing;
        AttackSpeed = attackSpeed;
        ElementTyping = elementTyping;
    }

    /// <summary> Creates a preset with no stats</summary>
    /// <returns> Empty potion</returns>
    public static PotionPreset Empty()
    {
        return new PotionPreset("Empty Potion",0, 0, 0, 0, 0, 0, 0);
    }
}
