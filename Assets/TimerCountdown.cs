using UnityEngine;
using System.Collections;
using TMPro;

public class TimerCountdown : MonoBehaviour
{
    public float timeInSec;
    public TMP_Text clockText;
    public GameObject endMsg;

    public GameObject irlRoom;
    public GameObject whiteRoom;


    public float fadeDuration = 2.0f;

    public GameObject whiteEndSphere;
    private Material material;
    private Color originalColor;

    private bool doneDoingStuff = false;

    [SerializeField] private Color targetColor = Color.white;

    private bool isFading = false;

    public bool gameHasEnded = false;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        endMsg.SetActive(false);
        clockText = clockText.GetComponent<TextMeshProUGUI>();
        material = whiteEndSphere.GetComponent<Renderer>().material;
        originalColor = material.color;

    }

    // Update is called once per frame
    void Update()
    {
        if (timeInSec > 0)
        timeInSec -= Time.deltaTime;
        //clockText.text = timeInSec.ToString();
        UpdateTimerDisplay();

        if (timeInSec <= 0.0f && doneDoingStuff == false)
        {
            timerEnded();
            doneDoingStuff = true;
        }

    }

    void UpdateTimerDisplay()
    {
        if (timeInSec > 0.1)
        {
            // Calculate minutes and seconds
            int minutes = Mathf.FloorToInt(timeInSec / 60);
            int seconds = Mathf.FloorToInt(timeInSec % 60);

            // Update the UI Text
            clockText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    /*
    IEnumerator FadeIn()
    {
        while (true)
        {
            // Fade in
            Debug.Log("Fading in Ending");
            yield return StartCoroutine(Fade(0, 1));
            irlRoom.SetActive(false);
            whiteRoom.SetActive(true);
            StartCoroutine(FadeOut());
        }

    }*/

    IEnumerator FadeOut()
    {

        yield return StartCoroutine(Fade(1, 0));
        whiteEndSphere.SetActive(false);

    }

    void timerEnded()
    {
        //do your stuff here.
        endMsg.SetActive(true);
        //StartCoroutine(FadeIn());

        gameHasEnded = true;

        StartFadeIn();
        
    }


    IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float elapsedTime = 0;

        while (elapsedTime < fadeDuration / 2)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / (fadeDuration / 2));

            if (material != null)
            {
                Color newColor = new Color(originalColor.r, originalColor.g, originalColor.b, endAlpha);
                material.color = newColor;
            }

            yield return null;
        }

        // Ensure final alpha is set
        if (material != null)
        {
            Color finalColor = new Color(originalColor.r, originalColor.g, originalColor.b, endAlpha);
            material.color = finalColor;
        }
    }



    public void StartFadeIn()
    {
        if (!isFading && material != null)
        {
            StartCoroutine(FadeIn());
        }
    }

    private IEnumerator FadeIn()
    {
        isFading = true;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);
            material.color = Color.Lerp(originalColor, targetColor, t);
            yield return null;
        }

        material.color = targetColor; // Ensure the color is set to the target at the end
        isFading = false;
    }

}
