using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientManager : MonoBehaviour, IIngredient
{
    public byte IngredientID { get { return _ingredientID; } }
    public IngredientTypes IngredientType { get { return _ingredientType; } }

    [SerializeField] private byte _ingredientID;
    [SerializeField] private IngredientTypes _ingredientType;
}
