using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Co_routine 
{
    public IEnumerator Waiter(float delayTime)
    {
        Debug.Log("Before time delay");
        yield return new WaitForSeconds(delayTime);
        Debug.Log("After time delay");
        foreach (GameObject i in player_imitator.tagged_shirt_slots)
        {
            player_imitator.positionx = i.transform.position.x;
            player_imitator.positiony = i.transform.position.y;

            Vector2 position;
            position = new Vector3(player_imitator.positionx, player_imitator.positiony);

            //StartCoroutine(Waiter(delayTime));
        }
    }
}
