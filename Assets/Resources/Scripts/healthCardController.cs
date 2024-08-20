using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthCardController : MonoBehaviour
{
    public health playerHealth;

    void Awake(){
        playerHealth = GameObject.Find("player").GetComponent<health>();
    }


    bool[] f = {false, false};
    void Update(){

        if(Input.GetKeyDown(KeyCode.F)){
            transform.Find("0.5").GetComponent<SpriteRenderer>().enabled = !f[0];
            f[0] = !f[0];
        }

        if(Input.GetKeyDown(KeyCode.Z)){
            transform.Find("0").GetComponent<SpriteRenderer>().enabled = !f[1];
            f[1] = !f[1];
        }

    }
}
