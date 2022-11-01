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
 
    }
    public static void Play()
    {

        Time.timeScale = 1f;

    }

    // Update is called once per frame

}
