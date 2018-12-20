using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> A component which will create a potion with a combination of ingredients.</summary>
public partial class PotionHasher : MonoBehaviour
{
    public delegate void answerBrew(int potionKey);
    public static event answerBrew OnSuccesfullBrew;

    public Vector3 potPos;

    [SerializeField]
    private GameObject _potionPrefab;

    // temporary visible for the sprint 1 demo
    [SerializeField]
    private int _combinationKey = 0;
    [SerializeField]
    private bool _autoFailed = false;

    /// <summary> Adds the ingredient to the combination key.
    /// <para> Any ingredient added after the fourth one will automatically result in a failed potion.</para></summary>
    /// <param name="ingredientId"> The ID of the ingredient which will be used in the combination key.</param>
    public void AddIngedient(byte ingredientId)
    {
        // sets autoFailed to true when a ingedient gets added after the fourth one.
        if ((_combinationKey & 267386880) != 0)
        {
            _autoFailed = true;
            return;
        }
        _combinationKey <<= 8;
        _combinationKey |= ingredientId;
    }

    /// <summary> Creates a potion with the combination key</summary>
    public void CreatePotion()
    {

        // creates an instance of a potion
        var newPotion = Instantiate(_potionPrefab, potPos, Quaternion.identity);

        // Grabs the StatsCollection of the potion for further use.
        StatsCollection statsCol = newPotion.GetComponent<StatsCollection>();

        // Declares a preset variable  because in C# 4 "out variable declaration" is not available.
        PotionPreset potionPreset;



        // checks if the combination of ingredients has a valid result and creates the respective potion.
        if (!_autoFailed && _ingredientCombinations.TryGetValue(_combinationKey, out potionPreset))
        {
            // Adds the preset to the potion and gives it his name.
            statsCol += potionPreset;
            newPotion.name = potionPreset.PotionName;

            try
            {
                OnSuccesfullBrew(_combinationKey);
            }
            catch { }
        }
        else
        {
            statsCol += _failedPotion;
            newPotion.name = _failedPotion.PotionName;
        }

        //resets the combination key.
        _combinationKey = 0;
        _autoFailed = false;

        if (GameManager.Instance.DialogueName.AddFlags(DialogueFlags.ThrowPotion) != 0)
        {
            FindObjectOfType<AudioManager>().Play("TeleportToArena");
        }
    }

    // A collection of outcomes a combination can have. When a combination is invalid, _failedPotion is used instead.
    private static readonly PotionPreset _failedPotion = new PotionPreset("Failed Potion", 0, 0, 0, 0, 0, 0, 0);
}