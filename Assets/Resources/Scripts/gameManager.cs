using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public int cardCount = 0;
    public int totCards = 0; // see Awake() in cardController.cs

    public Dictionary<int, GameObject> cards = new Dictionary<int, GameObject>();

    public void UpdateCards(GameObject card){  // called when cards are added or removed from the scene
        int cardID = card.GetComponent<cardController>().id;
        if (cards.ContainsKey(cardID)) cards.Remove(cardID);
        else cards.Add(cardID, card);
        UpdatePlayLine();
    }

    private LineRenderer lineRenderer;

    void Start() {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.widthMultiplier = 0.2f; 
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.blue;
        lineRenderer.endColor = Color.blue;
        lineRenderer.startWidth = 0.2f;
        lineRenderer.endWidth = 0.2f;
    }

    List<KeyValuePair<int, GameObject>> sortedCards;

    public void UpdatePlayLine(){ // called when cards are dropped after being picked up
        sortedCards = cards.OrderBy(pair => pair.Value.transform.position.x).ToList();

        if (sortedCards.Count > 1) {
            lineRenderer.positionCount = sortedCards.Count;
            Vector3[] positions = new Vector3[sortedCards.Count];

            for (int i = 0; i < sortedCards.Count; i++) {
                positions[i] = new Vector3(sortedCards[i].Value.transform.position.x, 0.1f, sortedCards[i].Value.transform.position.z);
            }

            lineRenderer.SetPositions(positions);
        } else {
            lineRenderer.positionCount = 0;
        }
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.R)) { RunCards(); }
    }

    void RunCards(){
        foreach(KeyValuePair<int, GameObject> card in sortedCards) {
            card.Value.GetComponent<cardController>().DoCardAbility();
        }
    }
}