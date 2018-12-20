using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour {

    public GameObject winCanvas;
    public GameObject loseCanvas;
    public GameObject confetti;
    public AudioClip cheering;
    public AudioClip victory;
    private bool hasPlayedAudio;

    [SerializeField] GameObject GameController;
    MinionManager mM;

    void Start()
    {
        hasPlayedAudio = false;
        mM = GameController.GetComponent<MinionManager>();
    }

    void Update () {
    
    //Het kijkt of je minder dan 1 minion hebt
    if(mM.friendlyMinions.Count <= 0)
        {
            //als de huidige scene Introduction is laat het alleen de canvas zien met de intro tekst.
            if(SceneHelper.ActiveSceneID == SceneHelper.Introduction)
            {

                DialogueFlags D = GameManager.Instance.DialogueName.Flags;

                if (GameManager.Instance.DialogueName.AddFlags(DialogueFlags.firstLoss) != 0)
                {
                    FindObjectOfType<AudioManager>().Play("FirstLoss");

                }
            }
            //als de huidige scene niet Introduction is laat het alleen de canvas zien met de lose tekst.
            else
            {
                loseCanvas.SetActive(true);
            }
        }
        //Het kijkt of de enemy minder dan 1 minion heeft.
        else if(mM.enemyMinions.Count <= 0)
        {
            winCanvas.SetActive(true);
            confetti.SetActive(true);

            if (!hasPlayedAudio)
            {
                Debug.Log("HOI IK BEN AFGESPEELD");
                AudioSource.PlayClipAtPoint(victory, Vector3.zero, 0.5f);
                AudioSource.PlayClipAtPoint(cheering, Vector3.zero, 1);
                hasPlayedAudio = true;
            }

        }
    } 
}
