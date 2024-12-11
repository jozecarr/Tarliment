using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class healthCardController : MonoBehaviour
{
    public static health playerHealth;
    private static GameObject healthCard;

    void Awake(){
        playerHealth = GameObject.Find("player").GetComponent<health>();
        healthCard = GameObject.Find("Health");
    }

    void Update(){
        float avgHealth = playerHealth.GetAvgHealth();
        overlayUpdate(avgHealth);
    }

    //Limb References
    //OVERLAY
    private void overlayUpdate(float avgHealth){
        if(avgHealth < 0.75f && avgHealth >= 0.5f){
            showOnCard("AVG75");
        }
        else if(avgHealth < 0.50f && avgHealth >= 0.25f){
            swap("AVG75", "AVG50");
        }
        else if(avgHealth < 0.25f && avgHealth > 0.0f){
            swap("AVG50", "AVG25");
        }
        else if (avgHealth == 0.0f) {
            swap("AVG25", "AVG0");
        }
    }


    //Those are long as lines to remember, these are only for the Health card tho as its repeated way too much
    private void showOnCard(string cardname){
        healthCard.transform.Find(cardname).GetComponent<SpriteRenderer>().enabled = true;
    }
    private void hideOnCard(string cardname){
        healthCard.transform.Find(cardname).GetComponent<SpriteRenderer>().enabled = false;
    }
    //Hides the first, shows the 2nd. Used for progressing health card easier
    private void swap(string currentLayer, string newLayer){
        hideOnCard(currentLayer);
        showOnCard(newLayer);
    }
}   


