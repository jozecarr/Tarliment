using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    public health health;
    public healthCardController healthCardController;

    void Awake(){
        health = this.GetComponent<health>();
        healthCardController = GameObject.Find("Health").GetComponent<healthCardController>();
    }
}
