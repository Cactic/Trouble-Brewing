using System;

/// <summary>
/// The flags are used to indicate which potions have been brewed.
/// </summary>
[Flags]
public enum PotionFlags
{
    NoPotions = 0,
    PotionofLesserHealth = 1 << 0,
    PotionofLesserToughness = 1 << 1,
    PotionofGreaterPain = 1 << 2,
    PotionofLesserHaste = 1 << 3,
    PotionofLesserStrength = 1 << 4,
    PotionofLesserAttackSpeed = 1 << 5,
    PotionofLesserPiercing = 1 << 6,
    PotionofLesserPain = 1 << 7,
    PotionofLesserWeakness = 1 << 8,
    PotionofLesserSlowness = 1 << 9,
    PotionofLesserSloth = 1 << 10,
    PotionofHealth = 1 << 11,
    PotionofStrength = 1 << 12,
    PotionofHaste = 1 << 13,
    PotionofToughness = 1 << 14,
    PotionofPiercing = 1 << 15,
    PotionofPain = 1 << 16,
    PotionofWeakness = 1 << 17,
    PotionofSlowness = 1 << 18,
    PotionofSloth = 1 << 19,
    PotionofFrailty = 1 << 20,
    PotionofGreaterHealth = 1 << 21,
    PotionofGreaterStrength = 1 << 22,
    PotionofGreaterHaste = 1 << 23,
    PotionofGreaterAttackSpeed = 1 << 24,
    PotionofGreaterToughness = 1 << 25,
    PotionofGreaterPiercing = 1 << 26,
    PotionofGreaterWeakness = 1 << 27,
    PotionofGreaterSlowness = 1 << 28,
    PotionofGreaterSloth = 1 << 29,
    PotionofGreaterFrailty = 1 << 30,
    PotionofAttackSpeed = 1 << 31
}
