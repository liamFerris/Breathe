using UnityEngine;
using System.Collections;

[ExecuteInEditMode]

public class UnderWater_PostEffect : MonoBehaviour {

    public Material effect;
    public bool IsUnderwater = false;
    public static UnderWater_PostEffect instance;
     bool GetOutOfWater = false;

    public bool CallWetLens;
    float CurrentIntensity = 0f;

    void Awake()
    {
        instance = this;
        CurrentIntensity = 0f;
    }
    void OnRenderImage(RenderTexture source, RenderTexture destination) {
        
        if (effect)
        {
            effect.SetFloat("_Bypass", IsUnderwater == true ? 0f : 1f);
            effect.SetFloat("_WetLensIntensity", CurrentIntensity);
            Graphics.Blit(source, destination, effect);
        }
    }
    void Update()
    {
        if (CallWetLens)
        {
            CallWetLens = false;
            WetLensFx();
        }
        if (GetOutOfWater)
        {
            if (CurrentIntensity > 0f)
            {
                CurrentIntensity -= Time.deltaTime*0.6f;
            }
            else
            {
                CurrentIntensity = 0f;
                GetOutOfWater = false;
            }
        }
    }
    public void WetLensFx()
    {
        if (!GetOutOfWater)
        {
            GetOutOfWater = true;
            CurrentIntensity = 1f;
        }
    }
}