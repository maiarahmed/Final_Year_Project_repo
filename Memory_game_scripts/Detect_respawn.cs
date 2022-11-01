using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Diagnostics;

public class Detect_respawn : MonoBehaviour
{
    public static bool respawned_clicked = false;
    
    public void Detector()
    {
        respawned_clicked = true;
        UnityEngine.Debug.Log("respawned_clicked " + respawned_clicked);
        StartCoroutine(Waiter(2f));
    }

    IEnumerator Waiter(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        respawned_clicked = false;
        UnityEngine.Debug.Log("respawned_clicked " + respawned_clicked);
    }
}
