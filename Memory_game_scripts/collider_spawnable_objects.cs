using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider_spawnable_objects : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Spawnable")
        {
            Debug.Log("Collided with a Spawnable object");
            /*foreach (GameObject o in GameObject.FindGameObjectsWithTag("Spawnable"))
            {
                Destroy(o);
            }*/
           // Destroy(this.gameObject);
        }
    }
}
