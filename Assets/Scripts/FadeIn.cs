using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public Light lighting;
    float elapsedTime = 0f;

    void Start()
    {
        Invoke("Fade", 3);
    }

    void Fade()
    {
        StartCoroutine(FadeInScene());
    }

    IEnumerator FadeInScene()
    {
        float elapsedTime = 0f;
        float lightingLerp = 0;
        float ambientIntensityLerp = 0;
        do
        {
            lightingLerp = Mathf.Lerp(0, 1.08f, elapsedTime);
            ambientIntensityLerp = Mathf.Lerp(0, 1.2f, elapsedTime);
            elapsedTime += Time.deltaTime / 10f;
            lighting.intensity = lightingLerp;
            RenderSettings.ambientIntensity = ambientIntensityLerp;
            yield return new WaitForEndOfFrame();
        }
        while (elapsedTime * 10f < 7f);
    }
}