using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class IngredientInterface : MonoBehaviour {

    public TextMesh ingredientText;
    private GameObject ingredientChild;
    private VRTK_InteractableObject ingredient;
    private IngredientManager ingredientInfo;

	void Start () {
        ingredientText = GameObject.Find("IngredientInformation").GetComponent<TextMesh>();
        ingredientChild = GameObject.Find("IngredientInformation");
        ingredient = this.GetComponent<VRTK_InteractableObject>();
        ingredientInfo = this.GetComponent<IngredientManager>();

        ingredientChild.SetActive(false);
	}
	

	void Update () {
        //references to VRTK to check if object has been picked up by either controllers.
		if (ingredient.IsGrabbed() == true)
        {
            Debug.Log("Ingredient grabbed");
            ingredientChild.SetActive(true);
            ingredientText.text = ("Ingredient type: "+ingredientInfo.IngredientType + System.Environment.NewLine + "Ingredient name: " + gameObject.name );
        }
        else
        {
            ingredientChild.SetActive(false);
        }
 
	}
}
