using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenDarkener : MonoBehaviour
{
    public Image darkOverlay; // Reference to the UI Panel's Image component
    public float fadeSpeed = 0.75f; // Speed of fading (higher is faster)

    private float targetAlpha = 0f; // Desired alpha value

    void Update()
    {
        if (darkOverlay != null)
        {
            StartCoroutine(FadeWithDelay());
        }
    }

    private IEnumerator FadeWithDelay()
    {
        yield return new WaitForSeconds(0.5f); // Wait for 0.5 seconds

        Color currentColor = darkOverlay.color;
        float newAlpha = Mathf.MoveTowards(currentColor.a, targetAlpha, fadeSpeed * Time.deltaTime);
        darkOverlay.color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);
    }


    public void DarkenScreen()
    {
        targetAlpha = 1f; // Fully dark (opaque)
    }

    public void LightenScreen()
    {
        targetAlpha = 0f; // Fully light (transparent)
    }
}
