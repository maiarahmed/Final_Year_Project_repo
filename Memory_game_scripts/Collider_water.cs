using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collider_water : MonoBehaviour
{
    float delayTime = 0f;
    private Vector2 position;
    public Canvas canvas;
    private GameObject item;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "water_slot")
        {
            collision.gameObject.transform.tag = "Untagged";
            StartCoroutine(DelayAction(delayTime));

            position = collision.transform.position;

            GameObject item_to_spawn;
            item_to_spawn = Resources.Load("water - Copy") as GameObject;
            Destroy(gameObject);
            item = Instantiate(item_to_spawn, position, item_to_spawn.transform.rotation);
            item.transform.SetParent(canvas.transform, true);

        }
    }

    IEnumerator DelayAction(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        //Destroy(gameObject);
        Debug.Log("water is placed in correct slot");
    }
}
