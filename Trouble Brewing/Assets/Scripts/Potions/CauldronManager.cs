using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronManager : MonoBehaviour {

    private PotionHasher _hasher;
    private Explosion Exp;

    // Set to true to create potion.
    [SerializeField] public bool _createPotion = false;
    public bool[] ingredientsUsed;
    private bool liquidUsed;

    public GameObject WaterLiquid, MilkLiquid, DemonBloodLiquid;

    private float liquidHeight;
    public int ingredientTypes = 3;
    private Vector3 ingredientReject;

    public string[] ingredientStringList;
    public List<GameObject> UsedLiquids = new List<GameObject>();
    public AudioClip playPotSound;
    public AudioClip ingredientRejectionClip;
    public AudioClip ingredientAcceptClip;

    void Start () {
        //Used to get ingredientIDs to make potions.
        _hasher = GetComponent<PotionHasher>();

        //Used for particleeffect when potion is created.
        Exp = GetComponent<Explosion>();

        liquidHeight = 1f;
        ingredientReject = new Vector3(0.2f, 10f, 0.2f);

        ingredientsUsed = new bool[ingredientTypes];

        //Used to check if a liquid is already used so as to not put multiple liquids in the cauldron.
        liquidUsed = false;
        ingredientStringList = new string[ingredientTypes];

        //Liquids need to be initialized this way otherwise they cant be collectively deactivated.
        WaterLiquid.SetActive(false);
        MilkLiquid.SetActive(false);
        DemonBloodLiquid.SetActive(false);

        //Liquids are added to this list to be collectively deactivated when a potion is created.
        UsedLiquids.Add(WaterLiquid);
        UsedLiquids.Add(MilkLiquid);
        UsedLiquids.Add(DemonBloodLiquid);
    }

    void Update()
    {
        if (_createPotion)
        {
            _createPotion = false;

            //Creates potion based on the ingredients added.
            _hasher.CreatePotion();

            //Creates explosion on position of potion spawn.
            Exp.Boom(_hasher.potPos);

            AudioSource.PlayClipAtPoint(playPotSound, _hasher.potPos, 1f);

            //Sets all ingredientsUsed to false so that ingredients can be added to the cauldron again.
            for (int i = 0; i < ingredientsUsed.Length; i++)
            { ingredientsUsed[i] = false; }

            //Same as previous comment only for the liquid used.
            foreach (GameObject liq in UsedLiquids)
            {
                liq.SetActive(false);
            }
            
            //Set to false so that the next liquid can be activated in the cauldron.
            liquidUsed = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //bounces away any item that isn't an ingredient.
        if (other.CompareTag("interactable"))
        {
            Debug.Log("That's not an ingredient!");
            other.GetComponent<Rigidbody>().AddForce(ingredientReject, ForceMode.Impulse);
            AudioSource.PlayClipAtPoint(ingredientRejectionClip, transform.position, 0.5f);
        }

        if (other.CompareTag("Ingredient"))
        {
            //Uses the amount of ingredientypes to set corresponding amount of cases.
            int EnumIntCast = (int)other.GetComponent<IngredientManager>().IngredientType;
            //Needed to check which ingredient was added to the brew.
            var ingredient = other.GetComponent<IngredientManager>();

            switch (EnumIntCast)
            {
                case 0: //Liquid
                    if (!ingredientsUsed[0]) //Checks if Liquid hasnt been added yet.
                    {
                        //adds the ingredient to the brew.
                        _hasher.AddIngedient(ingredient.IngredientID);

                        //Plays sound bit for accepting an ingredient.
                        AudioSource.PlayClipAtPoint(ingredientAcceptClip, transform.position, 0.5f);

                        ingredientsUsed[0] = true;
                        //Adds ingredient name to a public list so as to see what's already in the cauldron.
                        ingredientStringList[0] = other.name;
                        Debug.Log(other.GetComponent<IngredientManager>().IngredientType + "added.");

                        other.gameObject.SetActive(false);
                    }
                    else
                    {
                        Debug.Log("Already added" + other.GetComponent<IngredientManager>().IngredientType + "To the pot");
                        //Bounces ingredient out of the cauldron if the same type has already been used or the ingredients weren't added in the right order. Aswell as playing a little rejection sound bit.
                        other.GetComponent<Rigidbody>().AddForce(ingredientReject, ForceMode.Impulse);
                        AudioSource.PlayClipAtPoint(ingredientRejectionClip, transform.position, 0.5f);
                    }
                    break;
                case 1: //Magic
                    if (!ingredientsUsed[1] && ingredientsUsed[0]) //Checks if a liquid was already added and a magic items hasnt been.
                    {
                        _hasher.AddIngedient(ingredient.IngredientID);

                        AudioSource.PlayClipAtPoint(ingredientAcceptClip, transform.position, 0.5f);

                        ingredientsUsed[1] = true;
                        ingredientStringList[1] = other.name;
                        Debug.Log(other.GetComponent<IngredientManager>().IngredientType + "added.");

                        other.gameObject.SetActive(false);

                    }
                    else
                    {
                        Debug.Log("Already added" + other.GetComponent<IngredientManager>().IngredientType + "To the pot");
                        other.GetComponent<Rigidbody>().AddForce(ingredientReject, ForceMode.Impulse);
                        AudioSource.PlayClipAtPoint(ingredientRejectionClip, transform.position, 0.5f);
                    }
                    break;
                case 2: //Extra
                    if (!ingredientsUsed[2] && ingredientsUsed[0] && ingredientsUsed[1]) //Checks if liquid and magic have already been added and Extra hasnt been.
                    {
                        _hasher.AddIngedient(ingredient.IngredientID);

                        AudioSource.PlayClipAtPoint(ingredientAcceptClip, transform.position, 0.5f);

                        ingredientsUsed[2] = true;
                        ingredientStringList[2] = other.name;
                        Debug.Log(other.GetComponent<IngredientManager>().IngredientType + "added.");

                        other.gameObject.SetActive(false);
                        if (GameManager.Instance.DialogueName.AddFlags(DialogueFlags.makePotions) != 0)
                        {
                            FindObjectOfType<AudioManager>().Play("Stir");
                        }
                    }
                    else
                    {
                        Debug.Log("Already added" + other.GetComponent<IngredientManager>().IngredientType + "To the pot");
                        other.GetComponent<Rigidbody>().AddForce(ingredientReject, ForceMode.Impulse);
                        AudioSource.PlayClipAtPoint(ingredientRejectionClip, transform.position, 0.5f);
                    }
                    break;

            }
            //These create a liquid in the Cauldron based on the liquid ingredient added to the cauldron.
            if (other.gameObject.name == ("Water") && !liquidUsed)
            {
                Debug.Log("Water Added");
                WaterLiquid.SetActive(true);
                liquidUsed = true;
            }
            if (other.gameObject.name == ("Milk") && !liquidUsed)
            {
                Debug.Log("Milk Added");
                MilkLiquid.SetActive(true);
                liquidUsed = true;
            }
            if (other.gameObject.name == ("DemonBlood") && !liquidUsed)
            {
                Debug.Log("DemonBlood Added");
                DemonBloodLiquid.SetActive(true);
                liquidUsed = true;
            }
        }   
    }
}



