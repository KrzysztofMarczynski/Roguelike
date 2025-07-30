using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public Text clockText;
    private int h = 8;
    private int m = 0;
    private float timeCounter = 0f;
    private float colonBlinkTimer = 0f;
    private int colonState = 0;

    void Update()
    {
        timeCounter += Time.deltaTime;
        colonBlinkTimer += Time.deltaTime;


        if (timeCounter >= 5f)
        {
            timeCounter -= 5f;
            m += 1;

            if (m >= 60)
            {
                m -= 60;
                h += 1;
                if (h >= 24) h = 0;
            }
        }

        if (colonBlinkTimer >= 0.25f)
        {
            colonBlinkTimer -= 0.25f;
            colonState = (colonState + 1) % 2;
        }

        string colon;
        switch (colonState)
        {
            case 0: colon = ":."; break;
            case 1: colon = ".:"; break;

            default: colon = ".:"; break; // fallback
        }

        clockText.text = h.ToString("00") + colon + m.ToString("00");
    }
}
