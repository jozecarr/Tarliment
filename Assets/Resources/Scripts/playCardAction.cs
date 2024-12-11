using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playCardAction : MonoBehaviour
{
    health playerHealth;

    public float force = 0f;
    public float piercing = 0f; // stab, penetration

    void Awake() {
        playerHealth = GameObject.Find("player").GetComponent<health>();
    }

    public void Activate() {
        float fleshDmg = force * piercing;
        float fractDmg = force * (1 - piercing);
        playerHealth.ApplyDamage("left", "leg", -fleshDmg, -fractDmg);
        playerHealth.printHealth();
    }
}
