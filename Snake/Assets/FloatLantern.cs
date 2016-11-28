using UnityEngine;
using System.Collections;

public class FloatLantern : MonoBehaviour
{

    public float floatX;
    public float floatY;
    public float floatZ;
    
    void Update()
    {
        floatX = Mathf.Cos(Time.timeSinceLevelLoad) / 100;
        floatY = Mathf.Sin(Time.timeSinceLevelLoad) / 100;
        floatZ = -Mathf.Cos(Time.timeSinceLevelLoad) / 100;

        transform.position += new Vector3(0, floatY, 0);
    }
}
