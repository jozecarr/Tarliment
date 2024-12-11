using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class healthCardController : MonoBehaviour
{
    public health playerHealth;
    private GameObject healthCard;

    private (float, string, string)[] limbReference= 
    {(1.0f,"chest", "CH")};

    void Awake(){
        playerHealth = GameObject.Find("player").GetComponent<health>();
        healthCard = GameObject.Find("Health");
    }

    public void UpdateLimbs(){
        overlayUpdate(playerHealth.GetAvgHealth());
        foreach (var side in playerHealth.healthVals) {
            foreach (var part in side.Value){
                string prefix = side.Key.Substring(0, 1).ToUpper() + part.Key.Substring(0, 1).ToUpper();  
                //ex, chest = MC, left leg = LL, right arm = RA, neck = MN
                limbUpdate(part.Value.Item1, prefix);
            }
        }
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

    private void limbUpdate(float health, string filePrefix) {
        replace(filePrefix, filePrefix + ((Math.Round(health, 1) * 100)).ToString());
    }
    //Those are long as lines to remember, these are only for the Health card tho as its repeated way too much
    private void showOnCard(string bodyPart) {
        healthCard.transform.Find(bodyPart).GetComponent<SpriteRenderer>().enabled = true;
    }
    private void hideOnCard(string bodyPart) {
        healthCard.transform.Find(bodyPart).GetComponent<SpriteRenderer>().enabled = false;
    }
    private void replace(string prefix, string newLayer) {
        for(int i = 0; i < 11; i++){
            hideOnCard(prefix + (i * 10));
        }
        showOnCard(newLayer);
    }
    //Hides the first, shows the 2nd. Used for progressing health card easier
    private void swap(string currentLayer, string newLayer){
        hideOnCard(currentLayer);
        showOnCard(newLayer);
    }
}   


