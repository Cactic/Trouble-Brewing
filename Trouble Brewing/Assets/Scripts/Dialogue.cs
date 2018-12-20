using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Dialogue : MonoBehaviour {
    [SerializeField, BitMask(typeof(DialogueFlags))] private DialogueFlags _flags;

    public DialogueFlags Flags { get { return _flags; } }

    /// <summary> AddFlags behoudt het aantal bits dat hij al is geshift,
    /// hij voegt de addedFlags eraan toe en shift de bit naar die bit
    /// en returnt de nieuwe bit</summary>
    /// <param name="addedFlags"></param>
    /// <returns></returns>
    public DialogueFlags AddFlags(DialogueFlags addedFlags)
    {
        DialogueFlags changedFlags = (addedFlags ^ _flags) & addedFlags;
        _flags |= addedFlags;
        return changedFlags;
    }

}

[Flags]
public enum DialogueFlags
{
    NotNew = 1 << 0,
    firstLoss = 1 << 1,
    FirstTeleport = 1 << 2,
    CrystalBall = 1 << 3,
    makePotions = 1 << 4,
    ThrowPotion = 1 << 5
}

public static class DialogueExtentions
{
    public static bool CheckFlags(this DialogueFlags activeFlags,DialogueFlags flags)
    {
        return flags == (activeFlags & flags);
    }
}