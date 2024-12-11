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

    public void printHealth() {
        Debug.Log(   "left arm fl: " + healthVals["left"]["arm"].Item1    );
        Debug.Log(  "left hand fl: " + healthVals["left"]["hand"].Item1   );
        Debug.Log(   "left leg fl: " + healthVals["left"]["leg"].Item1    );

        Debug.Log(       "head fl: " + healthVals["mid"]["head"].Item1    );
        Debug.Log(       "neck fl: " + healthVals["mid"]["neck"].Item1    );
        Debug.Log(      "chest fl: " + healthVals["mid"]["chest"].Item1   );
        Debug.Log(    "stomach fl: " + healthVals["mid"]["stomach"].Item1 );
        
        Debug.Log(  "right arm fl: " + healthVals["right"]["arm"].Item1   );
        Debug.Log( "right hand fl: " + healthVals["right"]["hand"].Item1  );
        Debug.Log(  "right leg fl: " + healthVals["right"]["leg"].Item1   );

        

        Debug.Log(   "left arm fr: " + healthVals["left"]["arm"].Item2    );
        Debug.Log(  "left hand fr: " + healthVals["left"]["hand"].Item2   );
        Debug.Log(   "left leg fr: " + healthVals["left"]["leg"].Item2    );

        Debug.Log(       "head fr: " + healthVals["mid"]["head"].Item2    );
        Debug.Log(       "neck fr: " + healthVals["mid"]["neck"].Item2    );
        Debug.Log(      "chest fr: " + healthVals["mid"]["chest"].Item2   );
        Debug.Log(    "stomach fr: " + healthVals["mid"]["stomach"].Item2 );
        
        Debug.Log(  "right arm fr: " + healthVals["right"]["arm"].Item2   );
        Debug.Log( "right hand fr: " + healthVals["right"]["hand"].Item2  );
        Debug.Log(  "right leg fr: " + healthVals["right"]["leg"].Item2   );
    }
}
