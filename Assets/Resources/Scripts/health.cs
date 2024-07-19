using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class health : MonoBehaviour
{
    public Dictionary<string, Dictionary<string, float>> healthVals = new Dictionary<string, Dictionary<string, float>>()
    {
        { "mid", new Dictionary<string, float>
            {
                { "head", 1.0f },
                { "neck", 1.0f },
                { "chest", 1.0f},
                { "stomach", 1.0f},
            }
        },
        { "left", new Dictionary<string, float>
            {
                { "arm", 1.0f },
                { "hand", 1.0f},
                { "leg", 1.0f}
            }
        },
        { "right", new Dictionary<string, float>
            {
                { "arm", 1.0f},
                { "hand", 1.0f},
                { "leg", 1.0f}
            }
        }
    };

    public float GetAvgHealth(){
        float sum = 0;
        
        sum += healthVals["mid"]["head"];
        sum += healthVals["mid"]["neck"];
        sum += healthVals["mid"]["chest"];
        sum += healthVals["mid"]["stomach"];
        
        sum += healthVals["left"]["arm"];
        sum += healthVals["left"]["hand"];
        sum += healthVals["left"]["leg"];

        sum += healthVals["right"]["arm"];
        sum += healthVals["right"]["hand"];
        sum += healthVals["right"]["leg"];
        
        return sum / 10;
    }
}
