using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cardController : MonoBehaviour
{
    public int id = 0;
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

    gameManager gm;

    void Awake() {
        gm = GameObject.Find("gameManager").GetComponent<gameManager>();
        gm.cardCount++;
        id = ++gm.totCards;
        gm.UpdateCards(transform.gameObject);
    }

    void OnDestroy() { 
        gm.UpdateCards(transform.gameObject);
    }

    public void DoCardAbility(){
        Debug.Log(id);
    }
}