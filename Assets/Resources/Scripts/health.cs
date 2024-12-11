using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class health : MonoBehaviour
{
    public Dictionary<string, Dictionary<string, (float, float)>> healthVals = new Dictionary<string, Dictionary<string, (float, float) >>()
    {
        { "mid", new Dictionary<string, (float, float)>
            {
                { "head", (1.0f, 1.0f) },
                { "neck", (1.0f, 1.0f) },
                { "chest", (1.0f, 1.0f)},
                { "stomach", (1.0f, 1.0f)},
            }
        },
        { "left", new Dictionary<string, (float, float)>
            {
                { "arm", (1.0f, 1.0f) },
                { "hand", (1.0f, 1.0f)},
                { "leg", (1.0f, 1.0f)}
            }
        },
        { "right", new Dictionary<string, (float, float)>
            {
                { "arm", (1.0f, 1.0f)},
                { "hand", (1.0f, 1.0f)},
                { "leg", (1.0f, 1.0f)}
            }
        }
    };

    public float GetAvgHealth(){
        (float, float) sum = (0,0);

        sum.Item1 += healthVals["mid"]["neck"].Item1;
        sum.Item1 += healthVals["mid"]["head"].Item1;
        sum.Item1 += healthVals["mid"]["chest"].Item1;
        sum.Item1 += healthVals["mid"]["stomach"].Item1;
        sum.Item1 += healthVals["left"]["arm"].Item1;
        sum.Item1 += healthVals["left"]["hand"].Item1;
        sum.Item1 += healthVals["left"]["leg"].Item1;
        sum.Item1 += healthVals["right"]["arm"].Item1;
        sum.Item1 += healthVals["right"]["hand"].Item1;
        sum.Item1 += healthVals["right"]["leg"].Item1;
        
        return sum.Item1 / 10;
    }

    public void ApplyDamage(string side, string part, float flesh, float fracture){
        healthVals[side][part] = (
            healthVals[side][part].Item1 + flesh, 
            healthVals[side][part].Item2 + fracture
        );
    }
}
