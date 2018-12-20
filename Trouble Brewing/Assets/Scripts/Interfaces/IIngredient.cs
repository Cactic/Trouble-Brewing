using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IIngredient
{
    byte IngredientID { get; }
    IngredientTypes IngredientType { get; }
}
