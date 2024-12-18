using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class cardMover : MonoBehaviour
{

    public static Vector3 ScreenPosToWorldPos(Vector3 screenPos, float depth)
    {
        screenPos.z = depth;
        return Camera.main.ScreenToWorldPoint(screenPos);
    }

    public static Vector3 GetWorldMousePos()
    {
        return ScreenPosToWorldPos(Input.mousePosition, Camera.main.transform.position.y);
    }

    GameObject card;
    bool cardIsHeld = false;

    public GameObject border;
    GameObject borderInstance;

    void Start() {
        borderInstance = Instantiate(border, new Vector3(0,1000,0), new Quaternion());
    }
    
    public float springConstant = 100f;
    public float dampingConstant = 50f;
    public float handHeight = 3f;

    void Update()
    {
        if(!cardIsHeld){
            if(Input.GetMouseButtonDown(0)){
                Vector3 rayDir = GetWorldMousePos() - Camera.main.transform.position;

                RaycastHit hit;
                bool didHit = Physics.Raycast(Camera.main.transform.position, rayDir, out hit);

                if(didHit){
                    if(hit.collider.gameObject.tag == "Card"){
                        card = hit.collider.gameObject;
                        card.GetComponent<cardController>().isBeingMoved = true;
                        cardIsHeld = true;
                    }
                }
            }
        } else {
            Rigidbody cardRB = card.GetComponent<Rigidbody>();
            borderInstance.transform.position = new Vector3(
                card.transform.position.x, 0, card.transform.position.z
            );

            if(Input.GetMouseButtonDown(0)){
                cardRB.useGravity = true;
                cardIsHeld = false;
                borderInstance.transform.position = new Vector3(0,1000,0);
                StartCoroutine(UpdatePlayLineOnPlaced());
            } else {
                cardRB.useGravity = false;
                cardRB.angularVelocity = new Vector3(0,0,0);

                Vector3 handPos = GetWorldMousePos() + new Vector3(0, handHeight, 0);
                Vector3 forceDir = handPos - card.transform.position;
                float seperation = forceDir.magnitude;

                forceDir.Normalize();

                Vector3 springForce = forceDir * seperation * springConstant;
                Vector3 dampingForce = -cardRB.velocity * dampingConstant;

                cardRB.AddForce(springForce + dampingForce);

                Quaternion targetQuat = Quaternion.Euler(
                    90 + cardRB.velocity.z + 180 * card.GetComponent<cardController>().rotMod, 0, cardRB.velocity.x
                );

                if(Input.GetKeyDown(KeyCode.F)) {
                    card.GetComponent<cardController>().rotMod++;

                }

                /////
                
                if(card.gameObject.name == "Health"){
                    if(card.GetComponent<cardController>().rotMod % 2 != 0){
                        card.transform.Find("Back").GetComponent<SpriteRenderer>().enabled = true;
                    } else {
                        card.transform.Find("Back").GetComponent<SpriteRenderer>().enabled = false;
                    };
                }

                ////

                cardRB.transform.rotation = Quaternion.Lerp(cardRB.transform.rotation, targetQuat, 0.03f);
            }
        }
        
    }

    IEnumerator UpdatePlayLineOnPlaced(){
        while(card.GetComponent<Rigidbody>().velocity.magnitude > 0.01){yield return null;}
        GameObject.Find("gameManager").GetComponent<gameManager>().UpdatePlayLine();
        
    }
}
