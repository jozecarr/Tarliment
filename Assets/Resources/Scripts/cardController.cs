using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cardController : MonoBehaviour
{
    public bool isBeingMoved = false;
    public static string cardType = "Blank";

    public int rotMod = 0;

    public static Sprite cardFront;

    void SetCardFront() {
        Transform childTransform = transform.Find("Front");
        Debug.Log(childTransform.name);
        childTransform.GetComponent<SpriteRenderer>().sprite = cardFront;
    }

    public void SetCardType(string name) {
        cardType = name;
        cardFront = Resources.Load<Sprite>("Textures/Fronts/" + cardType); // stop loading on set, load all on game start into maybe a dict
        SetCardFront();
    }


    bool f = true;
    void Update(){
        if(Input.GetKeyDown(KeyCode.L)){
            if(f){f=!f;
                SetCardType("Blank2");
                Debug.Log(cardFront.name);
            }else{f=!f;
                SetCardType("Blank");
                Debug.Log(cardFront.name);
            }
        }
    }
}