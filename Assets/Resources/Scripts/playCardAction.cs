using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playCardAction : MonoBehaviour
{
    public float force = 0f;
    public float piercing = 0f; // stab, penetration

    public void Activate() {
        GameObject health = GameObject.Find("Health").playerHealth;
    }
}
