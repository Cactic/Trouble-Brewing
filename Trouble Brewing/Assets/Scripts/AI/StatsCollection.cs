using UnityEngine;

/// <summary> A mutable collection of stats assignable to game objects</summary>
[System.Serializable]
public class StatsCollection : MonoBehaviour
{
    public float Health                 { get { return _health;         } set { _health = value;            } }
    public float MovementSpeed          { get { return _movementSpeed;  } set { _movementSpeed = value;     } }
    public float AttackPower            { get { return _attackPower;    } set { _attackPower = value;       } }
    public int Defence                  { get { return _defence;        } set { _defence = value;           } }
    public int Piercing                 { get { return _piercing;       } set { _piercing = value;          } }
    public float AttackSpeed            { get { return _attackSpeed;    } set { _attackSpeed = value;       } }
    public ElementTypes ElementTyping   { get { return _elementTyping;  } set { _elementTyping = value;     } }

    [SerializeField]
    private float
        _health,
        _movementSpeed,
        _attackPower,
        _attackSpeed;

    [SerializeField]
    private int
        _defence,
        _piercing;

    [SerializeField, BitMask(typeof(ElementTypes))] private ElementTypes _elementTyping;

    public string name;
    #region Operators
    /// <summary> Mutates the left side StatsCollection with the right side PotionPreset.</summary>
    public static StatsCollection operator +(StatsCollection leftCollection, PotionPreset rightImmutableStats)
    {
        leftCollection.Health += rightImmutableStats.Health;
        leftCollection.MovementSpeed += rightImmutableStats.MovementSpeed;
        leftCollection.AttackPower += rightImmutableStats.AttackPower;
        leftCollection.Defence += rightImmutableStats.Defence;
        leftCollection.Piercing += rightImmutableStats.Piercing;
        leftCollection.AttackSpeed += rightImmutableStats.AttackSpeed;
        leftCollection.ElementTyping |= rightImmutableStats.ElementTyping;

        return leftCollection;
    }
    #endregion

    /// <summary> Adds the stats of the parameter to the current StatsCollection.</summary>
    /// <param name="collection"> Collection to add to the current StatsCollection.</param>
    public void AddToStats(StatsCollection collection)
    {
        Health += collection.Health;
        MovementSpeed += collection.MovementSpeed;
        AttackPower += collection.AttackPower;
        Defence += collection.Defence;
        Piercing += collection.Piercing;
        AttackSpeed += collection.AttackSpeed;
        ElementTyping |= collection.ElementTyping;
    }

    /// <summary> Adds the stats of the parameter to the current StatsCollection with the class moddifier.</summary>
    /// <param name="collection"> Collection to add to the current StatsCollection.</param>
    /// <param name="minionClass"> The current class of the minion.</param>
    public void AddToStats(StatsCollection collection, MinionClasses minionClass)
    {
        switch (minionClass)
        {
            case MinionClasses.MeleeMinion:
                Health += collection.Health;
                MovementSpeed += collection.MovementSpeed;
                AttackPower += collection.AttackPower;
                Defence += collection.Defence;
                Piercing += collection.Piercing;
                AttackSpeed += collection.AttackSpeed;
                ElementTyping |= collection.ElementTyping;
                break;

            default:
                throw new System.Exception("Unhandled minion Class in StatsCollection");
        }
    }

    /// <summary> Adds the stats of the parameter to the current StatsCollection.</summary>
    /// <param name="collection"> Collection to add to the current StatsCollection.</param>
    public void AddToStats(UnattachableStatsCollection collection)
    {
        Health += collection.Health;
        MovementSpeed += collection.MovementSpeed;
        AttackPower += collection.AttackPower;
        Defence += collection.Defence;
        Piercing += collection.Piercing;
        AttackSpeed += collection.AttackSpeed;
        ElementTyping |= collection.ElementTyping;
    }

    /// <summary> Adds the stats of the parameter to the current StatsCollection with the class moddifier.</summary>
    /// <param name="collection"> Collection to add to the current StatsCollection.</param>
    /// <param name="minionClass"> The current class of the minion.</param>
    public void AddToStats(UnattachableStatsCollection collection, MinionTypes minionClass)
    {
        switch (minionClass)
        {
            case MinionTypes.Melee:
                Health += collection.Health;
                MovementSpeed += collection.MovementSpeed;
                AttackPower += collection.AttackPower;
                Defence += collection.Defence;
                Piercing += collection.Piercing;
                AttackSpeed += collection.AttackSpeed;
                ElementTyping |= collection.ElementTyping;
                break;
            case MinionTypes.Mage:
                Health += collection.Health *0.2f;
                MovementSpeed += collection.MovementSpeed;
                AttackPower += collection.AttackPower;
                Defence += collection.Defence;
                Piercing += collection.Piercing;
                AttackSpeed += collection.AttackSpeed;
                ElementTyping |= collection.ElementTyping;
                break;
            case MinionTypes.Archer:
                Health += collection.Health;
                MovementSpeed += collection.MovementSpeed;
                AttackPower += collection.AttackPower;
                Defence += collection.Defence;
                Piercing += collection.Piercing;
                AttackSpeed += collection.AttackSpeed;
                ElementTyping |= collection.ElementTyping;
                break;

            default:
                throw new System.Exception("Unhandled minion Class in StatsCollection");
        }
    }

    /// <summary> Creates a clone of the current StatsCollection to be used sepperatly from the current one.</summary>
    /// <returns> Clone of the current StatsCollection.</returns>
    public StatsCollection Clone()
    {
        return new StatsCollection
        {
            Health = _health,
            MovementSpeed = _movementSpeed,
            AttackPower = _attackPower,
            Defence = _defence,
            Piercing = _piercing,
            AttackSpeed = _attackSpeed,
            ElementTyping = _elementTyping
        };
    }

    /// <summary> Reset all stats of this instance to 0.</summary>
    public void SetToZero()
    {
        _health = 0;
        _movementSpeed = 0;
        _attackPower = 0;
        _defence = 0;
        _piercing = 0;
        _attackSpeed = 0;
        _elementTyping = 0;
    }

    /// <summary> Creates a new StatsCollection with all properties set to 0.</summary>
    /// <returns> New StatsCollection with all properties set to 0.</returns>
    public static StatsCollection CreateBlank()
    {
        return new StatsCollection
        {
            Health = 0,
            MovementSpeed = 0,
            AttackPower = 0,
            Defence = 0,
            Piercing = 0,
            AttackSpeed = 0,
            ElementTyping = 0
        };
    }
}

[System.Serializable]
public class UnattachableStatsCollection
{
    public float Health { get { return _health; } set { _health = value; } }
    public float MovementSpeed { get { return _movementSpeed; } set { _movementSpeed = value; } }
    public float AttackPower { get { return _attackPower; } set { _attackPower = value; } }
    public int Defence { get { return _defence; } set { _defence = value; } }
    public int Piercing { get { return _piercing; } set { _piercing = value; } }
    public float AttackSpeed { get { return _attackSpeed; } set { _attackSpeed = value; } }
    public ElementTypes ElementTyping { get { return _elementTyping; } set { _elementTyping = value; } }

    [SerializeField]
    private float
        _health,
        _movementSpeed,
        _attackPower,
        _attackSpeed;

    [SerializeField]
    private int
        _defence,
        _piercing;

    [SerializeField, BitMask(typeof(ElementTypes))] private ElementTypes _elementTyping;
}