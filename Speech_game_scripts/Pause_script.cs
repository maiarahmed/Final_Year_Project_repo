using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_script : MonoBehaviour
{
    // Start is called before the first frame update
   
    [SerializeField]
   
    public static void Pause()
    {
        
        Time.timeScale = 0f;
        UnityEngine.Debug.Log("Pause button pressed");
 
    }
    public static void Play()
    {

        Time.timeScale = 1f;
        UnityEngine.Debug.Log("Play button pressed");

    }

    // Update is called once per frame

}
