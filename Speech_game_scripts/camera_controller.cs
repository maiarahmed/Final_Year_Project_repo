using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controller : MonoBehaviour
{
    public static float speed = 1f;
    private Vector3 newPosition;
    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        bool turnback;
        newPosition.x -= Time.deltaTime * speed;
        transform.position = newPosition;
        
        if (newPosition.x <= -950)
        {
            turnback = true;
            while (turnback == true)
            {
                newPosition.x += Time.deltaTime * speed;
                //transform.position = newPosition;
                if(newPosition.x >= 1280)
                {
                    turnback = false;
                }
            }
        }
    }
}
