using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    public health health;

    void Awake(){
        health = this.GetComponent<health>();
    }
}
