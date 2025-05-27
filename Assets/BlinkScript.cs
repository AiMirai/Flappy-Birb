using TMPro;
using UnityEngine;

public class BlinkText : MonoBehaviour
{
    public float fadeDuration = 0.5f;      // Time for fade in/out
    public float visibleHoldDuration = 1f; // How long to stay fully visible
    private TextMeshProUGUI tmpText;

    void Start()
    {
        tmpText = GetComponent<TextMeshProUGUI>();
        StartCoroutine(BlinkSmooth());
    }

    System.Collections.IEnumerator BlinkSmooth()
    {
        while (true)
        {
            // Fade in
            for (float t = 0; t < fadeDuration; t += Time.deltaTime)
            {
                SetAlpha(t / fadeDuration);
                yield return null;
            }
            SetAlpha(1);

            // Hold visible
            yield return new WaitForSeconds(visibleHoldDuration);

            // Fade out
            for (float t = 0; t < fadeDuration; t += Time.deltaTime)
            {
                SetAlpha(1 - (t / fadeDuration));
                yield return null;
            }
            SetAlpha(0);
        }
    }

    void SetAlpha(float alpha)
    {
        if (tmpText != null)
        {
            Color color = tmpText.color;
            color.a = alpha;
            tmpText.color = color;
        }
    }
}