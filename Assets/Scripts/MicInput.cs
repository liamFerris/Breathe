using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicInput : MonoBehaviour
{
    public AudioSource audioSource = new AudioSource();
    public static float micReading = 0;

    void Start()
    {
        audioSource.clip = Microphone.Start(null,
                    loop: true,
                    lengthSec: 1,
                    frequency: 4096
                    );
        audioSource.loop = true;
        while (!(Microphone.GetPosition(null) > 0)) { }
        //audioSource.Play();
    }

    private void Update()
    {
        float tempMicReading = MicLoudness();
        if (tempMicReading > 0.001)
        {
            micReading = MicLoudness();
        }
        else
            micReading = 0;
    }

    private float MicLoudness()
    {
        int sampleWindow = 128;
        float levelMax = 0;
        float[] waveData = new float[sampleWindow];
        int micPosition = Microphone.GetPosition(null) - (sampleWindow + 1);

        if (micPosition < 0)
            return 0;

        audioSource.clip.GetData(waveData, micPosition);

        for (int i = 0; i < sampleWindow; i++)
        {
            float wavePeak = waveData[i] * waveData[i];
            if (levelMax < wavePeak)
                levelMax = wavePeak;
        }
        return levelMax;
    }
}