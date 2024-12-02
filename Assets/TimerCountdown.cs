using UnityEngine;
using UnityEngine.UI;

public class TimerCountdown : MonoBehaviour
{
    public float timeInSec;
    public Text clockText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeInSec -= Time.deltaTime;
        clockText.text = timeInSec.ToString();

        if (timeInSec <= 0.0f)
        {
            timerEnded();
        }

    }

    void timerEnded()
    {
        //do your stuff here.
    }
}
