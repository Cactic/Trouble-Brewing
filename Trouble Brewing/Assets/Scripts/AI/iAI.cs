using UnityEngine;

//interface forces classes who inherit from it to use the functions and methods inside the interface
public enum Alliance
{
    Enemy,
    Player
};

public enum MinionTypes
{
    Archer,
    Melee,
    Mage

};

public interface iAI
{
    Coroutine AttackRoutine { get; set; }
    Alliance Faction { get; }
    MinionTypes MinionType { get; }
    Vector3 Location { get; }
    iAI Target { get; set; }
    bool IsInRange { get; }
    StatsCollection StatsCol { get; }

    void FireSpell(float fireSpellPower);
    void HealthSpell(float HealAmount);
    void EmitHealParticles();
    void EmitFireParticles();
}

public interface iMinionManager
{
    void DoDamage(iAI caller);
}