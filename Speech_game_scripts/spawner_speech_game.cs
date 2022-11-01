using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class spawner_speech_game : MonoBehaviour
{
    private List<Vector2> spawn_positions = new List<Vector2>();
    private Vector2 pos1, pos2, pos3, pos4, pos5, pos6, pos7, pos8, pos9, pos10,pos11, pos12, pos13, pos14, pos15
        , pos16, pos17, pos18, pos19, pos20, pos21, pos22, pos23, pos24, pos25, pos26, pos27, pos28, pos29,
        pos30, pos31, pos32, pos33, pos34, pos35, pos36;
    
    private int object_number;
    private int position_number;
    private int number_of_items;
    private GameObject toSpawn;
    private Vector2 pos;
    public static List<GameObject> objects = new List<GameObject>();
    private List<int> position_memory = new List<int>();
    private bool position_used;

    void Start()
    {
        //Store all objects with tag: speechobjects in a list
        
        //Debug.Log(objects.Count);
        foreach (GameObject o in objects)
        {
            Debug.Log(o.GetComponent<Text>().text); 
        }
        
        Debug.Log(spawn_positions.Count);
        position_used = false;
        //Store all possible spawn positions on the scene in a list
        pos1 = new Vector2(-1271, 385);
        pos2 = new Vector2(-1059, 385);
        pos3 = new Vector2(-882, 385);
        pos4 = new Vector2(-1271, 270);
        pos5 = new Vector2(-1059, 270);
        pos6 = new Vector2(-882, 270);
        pos7 = new Vector2(-1271, 159);
        pos8 = new Vector2(-1059, 159);
        pos9 = new Vector2(-882, 159);

        pos10 = new Vector2(-1271, -336);
        pos11 = new Vector2(-1059, -336);
        pos12 = new Vector2(-882, -336);
        pos13 = new Vector2(-1271, -460);
        pos14 = new Vector2(-1059, -460);
        pos15 = new Vector2(-882, -460);
        pos16 = new Vector2(-1271, -575);
        pos17 = new Vector2(-1059, -575);
        pos18 = new Vector2(-882, -575);

        pos19 = new Vector2(848, 385);
        pos20 = new Vector2(848, 385);
        pos21 = new Vector2(848, 385);
        pos22 = new Vector2(1069, 270);
        pos23 = new Vector2(1069, 270);
        pos24 = new Vector2(1069, 270);
        pos25 = new Vector2(1295, 159);
        pos26 = new Vector2(1295, 159);
        pos27 = new Vector2(1295, 159);

        pos28 = new Vector2(848, -336);
        pos29 = new Vector2(848, -336);
        pos30 = new Vector2(848, -336);
        pos31 = new Vector2(1069, -460);
        pos32 = new Vector2(1069, -460);
        pos33 = new Vector2(1069, -460);
        pos34 = new Vector2(1295, -575);
        pos35 = new Vector2(1295, -575);
        pos36 = new Vector2(1295, -575);

        spawn_positions.Add(pos1);
        spawn_positions.Add(pos2);
        spawn_positions.Add(pos3);
        spawn_positions.Add(pos4);
        spawn_positions.Add(pos5);
        spawn_positions.Add(pos6);
        spawn_positions.Add(pos7);
        spawn_positions.Add(pos8);
        spawn_positions.Add(pos9);
        spawn_positions.Add(pos10);
        spawn_positions.Add(pos11);
        spawn_positions.Add(pos12);
        spawn_positions.Add(pos13);
        spawn_positions.Add(pos14);
        spawn_positions.Add(pos15);
        spawn_positions.Add(pos16);
        spawn_positions.Add(pos17);
        spawn_positions.Add(pos18);
        spawn_positions.Add(pos19);
        spawn_positions.Add(pos20);
        spawn_positions.Add(pos21);
        spawn_positions.Add(pos22);
        spawn_positions.Add(pos23);
        spawn_positions.Add(pos24);
        spawn_positions.Add(pos25);
        spawn_positions.Add(pos26);
        spawn_positions.Add(pos27);
        spawn_positions.Add(pos28);
        spawn_positions.Add(pos29);
        spawn_positions.Add(pos30);
        spawn_positions.Add(pos31);
        spawn_positions.Add(pos32);
        spawn_positions.Add(pos33);
        spawn_positions.Add(pos34);
        spawn_positions.Add(pos35);
        spawn_positions.Add(pos36);

        number_of_items = 10;
        position_memory.Add(-1);
        for (int i = 0; i < number_of_items; i++)
        {
            //Generate random numbers
            object_number = Random.Range(0, objects.Count);
            position_number = Random.Range(0, spawn_positions.Count);
            //randomItem = 1;
            //Debug.Log("here 1");
            //Debug.Log(objects.Count);
            toSpawn = objects[object_number];
            //Debug.Log("here 2");

            pos = spawn_positions[position_number];

            for (int j = 0; j < position_memory.Count; j++)
            {
                if (position_number == position_memory[j])
                {
                    position_used = true;
                    //Debug.Log("here 3");

                }
            }
            if (position_used == false)
            {
                //Instantiate random object from object list at random position from position list
                GameObject Spawnedobj = Instantiate(toSpawn, pos, toSpawn.transform.rotation);
                Spawnedobj.transform.localScale = new Vector2(150,150);
                /*Debug.Log(object_number);
                Debug.Log(position_number);*/
            }
            position_used = false;
            position_memory.Add(position_number);
        }
        //Debug.Log(position_memory.Count);

    }



}
