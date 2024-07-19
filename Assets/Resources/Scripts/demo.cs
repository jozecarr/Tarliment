using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class demo : MonoBehaviour
{
    public Transform cardTrans;
    
    void Update()
    {
        cardTrans.Rotate(new Vector3(
            10f * Time.deltaTime,
            10f * Time.deltaTime,
            10f * Time.deltaTime
        ));
    }
}
