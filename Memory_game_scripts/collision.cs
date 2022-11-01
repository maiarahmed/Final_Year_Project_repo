using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class collision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        /*if (other.tag == "Spawnable")
        {
            
            Debug.Log(other.name); 
            /*foreach (GameObject o in GameObject.FindGameObjectsWithTag("Spawnable"))
            {
                Destroy(o);
            }*/
            // Destroy(this.gameObject);
        //}
        if (other.name == "shirt(Clone)")
        {
            transform.gameObject.tag = "shirt_slot";
        }
        if (other.name == "glasses(Clone)")
        {
            transform.gameObject.tag = "glasses_slot";
        }
        if (other.name == "Toothbrush(Clone)")
        {
            transform.gameObject.tag = "toothbrush_slot";
        }
        if (other.name == "water(Clone)")
        {
            transform.gameObject.tag = "water_slot";
        }


        if (other.name == "house(Clone)")
        {
            transform.gameObject.tag = "house_slot";
        }
        if (other.name == "socks(Clone)")
        {
            transform.gameObject.tag = "socks_slot";
        }
        if (other.name == "pencil(Clone)")
        {
            transform.gameObject.tag = "pencil_slot";
        }
        if (other.name == "chair(Clone)")
        {
            transform.gameObject.tag = "chair_slot";
        }

    }
}
