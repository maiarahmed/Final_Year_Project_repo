using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class microphone : MonoBehaviour
{

    public static int sampleWindow = 1500;
    public AudioClip microphoneClip;
    public static float[] waveData = new float[512];
    // Start recording with built-in Microphone and play the recorded audio right away
    void Start()
    {
        //MicrophoneToAudioClip();
    }

    public static void MicrophoneToAudioClip()
    {
        AudioSource audioSource = GameObject.Find("MicrophoneInput").GetComponent<AudioSource>();
        //string microphoneName = Microphone.devices[0];
        string microphoneName = "Microphone (Realtek Audio)";
        Debug.Log("Start recording");
        audioSource.clip = Microphone.Start(microphoneName,false, 5, 44100);
        //Microphone.End(microphoneName);
        Debug.Log("Stop recording");
        //audioSource.Play();
        Debug.Log("Playing recording");

    }

    public static float GetLoudnessFromMicrophone()
    {
        Debug.Log("in getloudnessfrom microphone");
        AudioSource audioSource = GameObject.Find("MicrophoneInput").GetComponent<AudioSource>();
        return GetLoudnessFromAudioClip(Microphone.GetPosition("Microphone (Realtek Audio)"), audioSource.clip);
    }

    public static float GetLoudnessFromAudioClip(int clipPosition, AudioClip clip)
    {
        Debug.Log("in getloudnessfrom audioclip");
        int startPosition = clipPosition - sampleWindow;

        /*if (startPosition < 0)
        {
            return 0;
        }*/
        AudioSource audioSource = GameObject.Find("MicrophoneInput").GetComponent<AudioSource>();
        //float[] waveData = new float[sampleWindow];
        //float[] waveData = new float[audioSource.clip.samples * audioSource.clip.channels];
        //float[] waveData = new float[512];
        audioSource.GetSpectrumData(waveData, 0, FFTWindow.Blackman);
        Debug.Log("waveData.Length " + waveData.Length);
        /*for (int i = 0; i < waveData.Length; i++)
        {
            Debug.Log("wavedata: " + waveData[i]);
        }*/

        for (int i = 1; i < waveData.Length - 1; i++)
        {
            //Debug.Log("Sketching spectrum");
            Debug.DrawLine(new Vector3(i - 1, waveData[i] + 10, 0), new Vector3(i, waveData[i + 1] + 10, 0), Color.red);
            Debug.DrawLine(new Vector3(i - 1, Mathf.Log(waveData[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(waveData[i]) + 10, 2), Color.cyan);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), waveData[i - 1] - 10, 1), new Vector3(Mathf.Log(i), waveData[i] - 10, 1), Color.green);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(waveData[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(waveData[i]), 3), Color.blue);
        }


        Array.Clear(waveData,0,waveData.Length);
        //compute loudness
        /*float totalLoudness = 0;

        for(int i = 0; i < sampleWindow; i++)
        {
            totalLoudness += Mathf.Abs(waveData[i]);
        }

        return totalLoudness / sampleWindow;*/
        return 0;
    }
}
