using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    public float fps;
    public Text text;

    void Update()
    {
        fps = 1.0f / Time.deltaTime;

        if(fps.ToString() == "Infinity")
        {
            text.text = "FPS: 200";
        }
        else
        {
            text.text = "FPS: " + Mathf.Floor(fps).ToString();
        }
    }
}
