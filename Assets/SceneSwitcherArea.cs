using System.Collections;
using UnityEngine;

public class SceneSwitcherArea : MonoBehaviour
{
    // Duration for a full fade cycle (fade in + fade out)
    public float fadeDuration = 2.0f;

    // Reference to the material of the attached object
    private Material material;
    private Color originalColor;

    public GameObject defaultScene;
    public GameObject sceneA;

    bool sceneFadedIn = false;

    void Start()
    {
        // Get the Renderer component and its material
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            material = renderer.material;
            originalColor = material.color; // Save the original color
        }
        else
        {
            Debug.LogError("No Renderer found on the GameObject. Attach this script to a GameObject with a Renderer.");
        }
    }

    IEnumerator FadeIn()
    {
        while (true && sceneFadedIn == false)
        {
            // Fade in
            Debug.Log("Fading in");
            yield return StartCoroutine(Fade(0, 1));
            sceneA.gameObject.SetActive(true);
            defaultScene.gameObject.SetActive(false);
            yield return StartCoroutine(Fade(1, 0));
            sceneFadedIn = true;
            Debug.Log("Called sceneFadeIn = true");
        }
        
    }

    IEnumerator FadeOut()
    {
        if (sceneFadedIn == true)
        {
            // Fade out
            Debug.Log("Fading out");
            yield return StartCoroutine(Fade(0, 1));
            sceneA.gameObject.SetActive(false);
            defaultScene.gameObject.SetActive(true);
            yield return StartCoroutine(Fade(1, 0));
            sceneFadedIn = false;
            Debug.Log("Called sceneFadeIn = false");
        }
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
                Color newColor = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
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
    private void OnTriggerEnter(Collider other)
    {
        //THE PLAYER ENTERS THE PORTAL
        Debug.Log("THE CAPSULE HAS ENTERED THE CHAT");
        StartCoroutine(FadeIn());

    }
    private void OnTriggerExit(Collider other)
    {
        //THE PLAYER ENTERS THE PORTAL
        Debug.Log("THE CAPSULE HAS LEFT  THE CHAT");
        StartCoroutine(FadeOut());

    }

}
