using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class get_children_speechobjects : MonoBehaviour
{
    public static List<GameObject> assetpool_speechobjects = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //assetpool_speechobjects = GetComponentsInChildren<Text>();
        /*foreach (GameObject t in transform)
        {
            assetpool_speechobjects.Add(t.gameObject);
        }*/
    }
}