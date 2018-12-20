using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using System;

[Serializable]
public class DictionaryTest : SerializableDictionary<int,RecipeContainer>
{}

[Serializable]
public class RecipeContainer
{
    [SerializeField]private GameObject _hiddenRecipe;
    [SerializeField] private PotionFlags potionFlag;

    public void HandlePotionMade()
    {
        //GameManager.Instance.FlaggedPotions & flag = result;

        if((GameManager.Instance.FlaggedPotions & potionFlag) == 0)
        {
            GameManager.Instance.FlaggedPotions |= potionFlag;
            _hiddenRecipe.SetActive(false);
        }
    }

    public void CheckFlagState()
    {
        if ((GameManager.Instance.FlaggedPotions & potionFlag) != 0)
        {
            _hiddenRecipe.SetActive(false);
            CrystallBall.Instance.CrystalBall.SetActive(true);
        }
    }
}

public class CrystallBall : VRTK_InteractableObject
{
    //Dictionary<long,GameObject>
    public GameObject _UIGameObject;
    public GameObject CrystalBall;
    public static CrystallBall Instance;

    [OurSerilizableDictionary(typeof(DictionaryTest))]
    public DictionaryTest RecipeDictionary;
    
    public override void StartUsing(VRTK_InteractUse usingObject)
    {
        Debug.Log("Started using ball");
        base.StartUsing(usingObject);
        UIControl();

        
    }

    protected void Start()
    {
        _UIGameObject.SetActive(false);
        Debug.Log(gameObject.name);

        PotionHasher.OnSuccesfullBrew += PotionHasher_OnSuccesfullBrew;

        foreach (var recipe in RecipeDictionary.Values)
        {
            recipe.CheckFlagState();
        }

        Instance = this;
    }

    //Dictionary<int, >

    private void PotionHasher_OnSuccesfullBrew(int potionKey)
    {
        RecipeContainer container;
        if (RecipeDictionary.TryGetValue(potionKey, out container))
        {
            container.HandlePotionMade();
        }
    }

    private void OnDestroy()
    {
        PotionHasher.OnSuccesfullBrew -= PotionHasher_OnSuccesfullBrew;
    }

    private void UIControl()
    {
        //Toggles the UI on or off.
        Debug.Log("toggled UI");
        if (_UIGameObject.activeInHierarchy == false)
        {
            _UIGameObject.SetActive(true);
            CrystalBall.SetActive(false);
            if (GameManager.Instance.DialogueName.AddFlags(DialogueFlags.CrystalBall) != 0)
            {
                FindObjectOfType<AudioManager>().Play("CrystalBall");
            }

        }
        else _UIGameObject.SetActive(false);
    }

    
}
