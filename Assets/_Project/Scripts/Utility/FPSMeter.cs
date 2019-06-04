using UnityEngine;
using UnityEngine.UI;

public class FPSMeter : MonoBehaviour
{
    public Text Display;
    private float deltaTime = 0.0f;

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);

        Display.text = text;
    }
}