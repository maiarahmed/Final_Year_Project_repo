using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Diagnostics;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public static float numberToSpawn;
    public int change_numberToSpawn;
    public List<GameObject> spawnPool;
    public GameObject quad;
    public static bool respawned = false;
    public  float radius = 150f;
    public static bool validPosition = true;
    public static float number_of_slots = 0f;

    public static float numberToSpawn_history;
    public static float number_of_slots_history = 0f;

    //public static Stopwatch timer;

    public static bool timer_bool = false;
    public static float reaction_time = 0;

    public GameObject celebration;

    //public Timer timer;
    /*private string path = "";
    private string persistentPath = "";*/

    public GameObject[] tagged_shirt_slots;
    public GameObject[] tagged_water_slots;
    public GameObject[] tagged_glasses_slots;
    public GameObject[] tagged_toothbrush_slots;
    public GameObject[] tagged_pencil_slots;
    public GameObject[] tagged_chair_slots;
    public GameObject[] tagged_house_slots;
    public GameObject[] tagged_socks_slots;

    public GameObject[] shirts;
    public GameObject[] toothbrushes;
    public GameObject[] socks;
    public GameObject[] pencils;
    public GameObject[] glasses;
    public GameObject[] chairs;
    public GameObject[] houses;
    public GameObject[] waters;

    public GameObject spawnPool_0;

    //create list to store spawned GameObjects
    
    List<GameObject> spawnedList = new List<GameObject>();

    public  List<GameObject> slotpool;
    public static List<GameObject> spawned_slots = new List<GameObject>();
    private static int space = 0;

    public static int sum = 0;

    private void Start()
    {
        
        numberToSpawn = 1;
        for (int i = 0; i < 15; i++)
        {
            Timer.dda_memory.Add(0);
        }
        
        number_of_slots = 2;
        adjust_no_of_slots(number_of_slots);
        
        //Create spawnpool list
        /*spawnPool_0 = Resources.Load("glasses") as GameObject;
        spawnPool[1] = Resources.Load("toothbrush") as GameObject;
        spawnPool[2] = Resources.Load("water") as GameObject;
        spawnPool[3] = Resources.Load("shirt") as GameObject;

        spawnPool.Add(spawnPool_0);*/
        UnityEngine.Debug.Log("spawnPool count in start " + spawnPool.Count);

        spawnObjects();
    }

    public static void adjust_no_of_slots(float number_of_slots)
    {
        GameObject slot_to_spawn;
        GameObject spawnedslot;
        //List<GameObject> spawned_slots = new List<GameObject>();
        //Debug.Log("slotpool count" + slotpool.Count);
        if (spawned_slots.Count > 1)
        {
            for (int i=0; i < spawned_slots.Count; i++)
            {
                if (spawned_slots[i] != null)
                {
                    Destroy(spawned_slots[i]);
                    UnityEngine.Debug.Log("destroy slot");
                }
            }
            
        }
        spawned_slots = new List<GameObject>();
        UnityEngine.Debug.Log("After deleting slots, spawned slots = " + spawned_slots.Count);
        space = 0;
        int j = 0;

        for (int i = 0; i < number_of_slots; i++)
        {

            //slot_to_spawn = slotpool[i];
            //slot_to_spawn = GameObject.Find("slot");

            slot_to_spawn = Resources.Load("slot") as GameObject;
            //GameObject obj = Instantiate(slot_to_spawn) as GameObject;

            //Create all variations of slot positions based on the number of slots
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width / 2), Screen.height / 2, Camera.main.nearClipPlane));
            if (number_of_slots == 2)
            {
                pos = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width / 2) + space, Screen.height / 2, Camera.main.nearClipPlane));
                space = space - 200;
                spawnedslot = Instantiate(slot_to_spawn, pos, slot_to_spawn.transform.rotation);
                //spawnedslot.transform.localScale = new Vector2(2, 2);
                GameObject slots_parent = GameObject.FindGameObjectWithTag("slots_parent");
                spawnedslot.transform.SetParent(slots_parent.transform);
                UnityEngine.Debug.Log("Adding slot to spawn");
                spawned_slots.Add(spawnedslot);
            }
            if (number_of_slots == 3)
            {
                pos = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width / 2) + space + 75, Screen.height / 2, Camera.main.nearClipPlane));
                space = space - 200;
                spawnedslot = Instantiate(slot_to_spawn, pos, slot_to_spawn.transform.rotation);
                //spawnedslot.transform.localScale = new Vector2(1.5, 2);
                GameObject slots_parent = GameObject.FindGameObjectWithTag("slots_parent");
                spawnedslot.transform.SetParent(slots_parent.transform);
                UnityEngine.Debug.Log("Adding slot to spawn");
                spawned_slots.Add(spawnedslot);
            }
            if (number_of_slots == 4)
            {
                if (j < 2)
                {
                    pos = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width / 2) + space - 65, (Screen.height / 2) - 100, Camera.main.nearClipPlane));
                    space = space - 200;
                    spawnedslot = Instantiate(slot_to_spawn, pos, slot_to_spawn.transform.rotation);
                    //spawnedslot.transform.localScale = new Vector2(1.5, 2);
                    GameObject slots_parent = GameObject.FindGameObjectWithTag("slots_parent");
                    spawnedslot.transform.SetParent(slots_parent.transform);
                    UnityEngine.Debug.Log("Adding slot to spawn");
                    spawned_slots.Add(spawnedslot);
                }


                if (j >= 2)
                {
                    pos = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width / 2) + space - 65, (Screen.height / 2) + 100, Camera.main.nearClipPlane));
                    space = space - 200;
                    spawnedslot = Instantiate(slot_to_spawn, pos, slot_to_spawn.transform.rotation);
                    //spawnedslot.transform.localScale = new Vector2(1.5, 2);
                    GameObject slots_parent = GameObject.FindGameObjectWithTag("slots_parent");
                    spawnedslot.transform.SetParent(slots_parent.transform);
                    UnityEngine.Debug.Log("Adding slot to spawn");
                    spawned_slots.Add(spawnedslot);
                }
                j++;
                if (j == 2)
                {
                    space = 0;
                }
            }

            if (number_of_slots == 5)
            {
                if (j < 2)
                {
                    pos = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width / 2) + space + 35, (Screen.height / 2) - 100, Camera.main.nearClipPlane));
                    space = space - 350;
                    spawnedslot = Instantiate(slot_to_spawn, pos, slot_to_spawn.transform.rotation);
                    //spawnedslot.transform.localScale = new Vector2(1.5, 2);
                    GameObject slots_parent = GameObject.FindGameObjectWithTag("slots_parent");
                    spawnedslot.transform.SetParent(slots_parent.transform);
                    UnityEngine.Debug.Log("Adding slot to spawn");
                    spawned_slots.Add(spawnedslot);
                }


                if ((j >= 2) && (j < 4))
                {
                    pos = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width / 2) + space + 35, (Screen.height / 2) + 100, Camera.main.nearClipPlane));
                    space = space - 350;
                    spawnedslot = Instantiate(slot_to_spawn, pos, slot_to_spawn.transform.rotation);
                    //spawnedslot.transform.localScale = new Vector2(1.5, 2);
                    GameObject slots_parent = GameObject.FindGameObjectWithTag("slots_parent");
                    spawnedslot.transform.SetParent(slots_parent.transform);
                    UnityEngine.Debug.Log("Adding slot to spawn");
                    spawned_slots.Add(spawnedslot);
                }

                if (j == 4)
                {
                    pos = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width / 2) + 35 - 175, (Screen.height / 2), Camera.main.nearClipPlane));
                    spawnedslot = Instantiate(slot_to_spawn, pos, slot_to_spawn.transform.rotation);
                    //spawnedslot.transform.localScale = new Vector2(1.5, 2);
                    GameObject slots_parent = GameObject.FindGameObjectWithTag("slots_parent");
                    spawnedslot.transform.SetParent(slots_parent.transform);
                    UnityEngine.Debug.Log("Adding slot to spawn");
                    spawned_slots.Add(spawnedslot);
                }
                j++;
                if (j == 2)
                {
                    space = 0;
                }
            }
            if (number_of_slots == 6)
            {
                if (j < 3)
                {
                    pos = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width / 2) + space + 75, (Screen.height / 2) + 100, Camera.main.nearClipPlane));
                    space = space - 200;
                    spawnedslot = Instantiate(slot_to_spawn, pos, slot_to_spawn.transform.rotation);
                    //spawnedslot.transform.localScale = new Vector2(1.5, 2);
                    GameObject slots_parent = GameObject.FindGameObjectWithTag("slots_parent");
                    spawnedslot.transform.SetParent(slots_parent.transform);
                    UnityEngine.Debug.Log("Adding slot to spawn");
                    spawned_slots.Add(spawnedslot);
                }
                if (j >= 3)
                {
                    pos = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width / 2) + space + 75, (Screen.height / 2) - 100, Camera.main.nearClipPlane));
                    space = space - 200;
                    spawnedslot = Instantiate(slot_to_spawn, pos, slot_to_spawn.transform.rotation);
                    //spawnedslot.transform.localScale = new Vector2(1.5, 2);
                    GameObject slots_parent = GameObject.FindGameObjectWithTag("slots_parent");
                    spawnedslot.transform.SetParent(slots_parent.transform);
                    UnityEngine.Debug.Log("Adding slot to spawn");
                    spawned_slots.Add(spawnedslot);
                }
                j++;
                if (j == 3)
                {
                    space = 0;
                }


            }

            if (number_of_slots == 7)
            {
                if (j < 3)
                {
                    pos = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width / 2) + space + 75, (Screen.height / 2) + 125, Camera.main.nearClipPlane));
                    space = space - 200;
                    spawnedslot = Instantiate(slot_to_spawn, pos, slot_to_spawn.transform.rotation);
                    //spawnedslot.transform.localScale = new Vector2(1.5, 2);
                    GameObject slots_parent = GameObject.FindGameObjectWithTag("slots_parent");
                    spawnedslot.transform.SetParent(slots_parent.transform);
                    UnityEngine.Debug.Log("Adding slot to spawn");
                    spawned_slots.Add(spawnedslot);
                }
                if ((j >= 3) && (j < 6))
                {
                    pos = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width / 2) + space + 75, (Screen.height / 2) - 125, Camera.main.nearClipPlane));
                    space = space - 200;
                    spawnedslot = Instantiate(slot_to_spawn, pos, slot_to_spawn.transform.rotation);
                    //spawnedslot.transform.localScale = new Vector2(1.5, 2);
                    GameObject slots_parent = GameObject.FindGameObjectWithTag("slots_parent");
                    spawnedslot.transform.SetParent(slots_parent.transform);
                    UnityEngine.Debug.Log("Adding slot to spawn");
                    spawned_slots.Add(spawnedslot);
                }
                if (j == 6)
                {
                    pos = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width / 2) - 200 + 75, (Screen.height / 2), Camera.main.nearClipPlane));
                    spawnedslot = Instantiate(slot_to_spawn, pos, slot_to_spawn.transform.rotation);
                    //spawnedslot.transform.localScale = new Vector2(1.5, 2);
                    GameObject slots_parent = GameObject.FindGameObjectWithTag("slots_parent");
                    spawnedslot.transform.SetParent(slots_parent.transform);
                    UnityEngine.Debug.Log("Adding slot to spawn");
                    spawned_slots.Add(spawnedslot);
                }
                j++;
                if (j == 3)
                {
                    space = 0;
                }
            }

            if (number_of_slots == 8)
            {
                if (j < 4)
                {
                    pos = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width / 2) + space + 120, (Screen.height / 2) + 100, Camera.main.nearClipPlane));
                    space = space - 170;
                    spawnedslot = Instantiate(slot_to_spawn, pos, slot_to_spawn.transform.rotation);
                    //spawnedslot.transform.localScale = new Vector2(1.5, 2);
                    GameObject slots_parent = GameObject.FindGameObjectWithTag("slots_parent");
                    spawnedslot.transform.SetParent(slots_parent.transform);
                    UnityEngine.Debug.Log("Adding slot to spawn");
                    spawned_slots.Add(spawnedslot);
                }
                if (j >= 4)
                {
                    pos = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width / 2) + space + 120, (Screen.height / 2) - 100, Camera.main.nearClipPlane));
                    space = space - 170;
                    spawnedslot = Instantiate(slot_to_spawn, pos, slot_to_spawn.transform.rotation);
                    //spawnedslot.transform.localScale = new Vector2(1.5, 2);
                    GameObject slots_parent = GameObject.FindGameObjectWithTag("slots_parent");
                    spawnedslot.transform.SetParent(slots_parent.transform);
                    UnityEngine.Debug.Log("Adding slot to spawn");
                    spawned_slots.Add(spawnedslot);
                }
                j++;
                if (j == 4)
                {
                    space = 0;
                }

            }

            if (number_of_slots == 9)
            {
                if (j < 3)
                {
                    pos = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width / 2) + space + 75, (Screen.height / 2) + 130, Camera.main.nearClipPlane));
                    space = space - 200;
                    spawnedslot = Instantiate(slot_to_spawn, pos, slot_to_spawn.transform.rotation);
                    //spawnedslot.transform.localScale = new Vector2(1.5, 2);
                    GameObject slots_parent = GameObject.FindGameObjectWithTag("slots_parent");
                    spawnedslot.transform.SetParent(slots_parent.transform);
                    UnityEngine.Debug.Log("Adding slot to spawn");
                    spawned_slots.Add(spawnedslot);
                }
                if ((j >= 3) && (j < 6))
                {
                    pos = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width / 2) + space + 75, Screen.height / 2, Camera.main.nearClipPlane));
                    space = space - 200;
                    spawnedslot = Instantiate(slot_to_spawn, pos, slot_to_spawn.transform.rotation);
                    //spawnedslot.transform.localScale = new Vector2(1.5, 2);
                    GameObject slots_parent = GameObject.FindGameObjectWithTag("slots_parent");
                    spawnedslot.transform.SetParent(slots_parent.transform);
                    UnityEngine.Debug.Log("Adding slot to spawn");
                    spawned_slots.Add(spawnedslot);
                }
                if (j >= 6)
                {
                    pos = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width / 2) + space + 75, (Screen.height / 2) - 130, Camera.main.nearClipPlane));
                    space = space - 200;
                    spawnedslot = Instantiate(slot_to_spawn, pos, slot_to_spawn.transform.rotation);
                    //spawnedslot.transform.localScale = new Vector2(1.5, 2);
                    GameObject slots_parent = GameObject.FindGameObjectWithTag("slots_parent");
                    spawnedslot.transform.SetParent(slots_parent.transform);
                    UnityEngine.Debug.Log("Adding slot to spawn");
                    spawned_slots.Add(spawnedslot);
                }

                j++;
                if (j == 3)
                {
                    space = 0;
                }
                if (j == 6)
                {
                    space = 0;
                }
            }
        }
    }
    void Update()
    {
        tagged_shirt_slots = GameObject.FindGameObjectsWithTag("shirt_slot");
        tagged_water_slots = GameObject.FindGameObjectsWithTag("water_slot");
        tagged_glasses_slots = GameObject.FindGameObjectsWithTag("glasses_slot");
        tagged_toothbrush_slots = GameObject.FindGameObjectsWithTag("toothbrush_slot");
        tagged_chair_slots = GameObject.FindGameObjectsWithTag("chair_slot");
        tagged_pencil_slots = GameObject.FindGameObjectsWithTag("pencil_slot");
        tagged_house_slots = GameObject.FindGameObjectsWithTag("house_slot");
        tagged_socks_slots = GameObject.FindGameObjectsWithTag("socks_slot");

        if (timer_bool == true)
        {
            reaction_time += Time.deltaTime;
        }
        
        //number_of_slots = DDA_ML_agent.change_number_of_slots;
    }

    public void spawnObjects()
    {
        numberToSpawn_history = numberToSpawn;
        number_of_slots_history = number_of_slots;
        //Debug.Log(timer.dda_memory);
        respawned = true;
        adjust_no_of_slots(number_of_slots);
        //Debug.Log("respawned = true");
        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        destroyObjects();
        int randomItem = 0;
        GameObject toSpawn;

        List<int> slotList = new List<int>();

        //timer = new Stopwatch();
        //timer.Start();

        timer_bool = true;

        //MeshCollider c = quad.GetComponent<MeshCollider>();

        /*GameObject slot1 = GameObject.Find("slot");
        GameObject slot2 = GameObject.Find("slot "+ 1);
        GameObject slot3 = GameObject.Find("slot (2)");
        GameObject slot4 = GameObject.Find("slot (3)");
        GameObject slot5 = GameObject.Find("slot (4)");
        GameObject slot6 = GameObject.Find("slot (5)");
        GameObject slot7 = GameObject.Find("slot (6)");
        GameObject slot8 = GameObject.Find("slot (7)");
        GameObject slot9 = GameObject.Find("slot (8)");*/

        StartCoroutine(Waiter(0.5f));

        //celebration.SetActive(true);
        //StartCoroutine(Waiter2(2f));

        float screenX, screenY;
        Vector2 pos;
        /*int[] chosenslot = new int[50];
        int[] chosentoSpawn = new int[50];*/

        int i = 0;

        while(i < numberToSpawn)
        {
            //Randomly choose an item from the range of GameObjects 
            //Debug.Log("spawnPool count " + spawnPool.Count);
            randomItem = Random.Range(0, spawnPool.Count);
            toSpawn = spawnPool[randomItem];

            //Randomly choose a slot
            int slotnumber = Random.Range(0, spawned_slots.Count);
            GameObject slot = spawned_slots[slotnumber];
            //Debug.Log("In spawner spawn objects");

            //Store chosen slots in list
            slotList.Add(slotnumber);
            validPosition = true;

            //Debug.Log("Spawned slots count: "+ spawned_slots.Count);
           
            //Find the position of the slot chosen randomly
            screenX = slot.transform.position.x;
            screenY = slot.transform.position.y;
            pos = new Vector2(screenX, screenY);
            
  
            /*Collider2D[] colliders = Physics2D.OverlapCircleAll(pos, radius);
            //Instantiate the GameObject at the slot position
            foreach(Collider2D col in colliders)
            {
                UnityEngine.Debug.Log("collider tag: " + col.tag.ToString());
                if (col.tag.ToString() == "Spawnable")
                {
                    validPosition = false;
                    UnityEngine.Debug.Log("Not a valid position to spawn item"  + col);
                }
                else if (validPosition == true)
                {
                    UnityEngine.Debug.Log("valid position = " + validPosition);
                    UnityEngine.Debug.Log("instantiating " + toSpawn);
                    GameObject Spawnedobj = Instantiate(toSpawn, pos, toSpawn.transform.rotation);
                    Spawnedobj.transform.SetParent(canvas.transform);
                }
            }*/

            for (int k = 0; k < slotList.Count-1; k ++)
            {
                if (slotList[k] == slotnumber)
                {
                    validPosition = false;
                }
            }

            if(validPosition == true)
            {
                GameObject Spawnedobj = Instantiate(toSpawn, pos, toSpawn.transform.rotation);
                Spawnedobj.transform.SetParent(canvas.transform);
                i++;
            }

        }

        //Debug.Log("Before ML");
        //Debug.Log("Timer on click bool " + Detect_respawn.respawned_clicked);
        // generate new number to spawn variable based on number of correct and incorrect tries.
        /*int j = 0;
        int sum = 0;

        for(j = (Timer.dda_memory.Count - 10); j < Timer.dda_memory.Count; j++)
        {
            //if (Detect_respawn.respawned_clicked == false)
            
                sum = sum + Timer.dda_memory[j];
            
        }*/
        //UnityEngine.Debug.Log("sum " + sum);
        //numberToSpawn = change_numberToSpawn;
        //numberToSpawn = sum;
        //number_of_slots = numberToSpawn + 1f;

        //number_of_slots = Random.Range(2,9);
        //number_of_slots = DDA_ML_agent.change_number_of_slots;
        if (DDA_ML_agent.change_number_of_slots <= 1)
        {
            number_of_slots = 3;
            UnityEngine.Debug.Log("NN gave 0 slots");
        }
        else if(DDA_ML_agent.change_number_of_slots > 1)
        {
            number_of_slots = DDA_ML_agent.change_number_of_slots;
        }

        if (DDA_ML_agent.change_number_to_spawn > DDA_ML_agent.change_number_of_slots)
        {
            numberToSpawn = 2;
            UnityEngine.Debug.Log("NN number to spawn less than slots");
        }
        else if (DDA_ML_agent.change_number_to_spawn < DDA_ML_agent.change_number_of_slots)
        {
            numberToSpawn = DDA_ML_agent.change_number_to_spawn;
        }


        //number_of_slots = 3;
        //numberToSpawn = Mathf.Ceil(Random.Range(1, number_of_slots - 1));
        validPosition = true;
        respawned = false;
        //Debug.Log("Number of slots to spawn: " + number_of_slots);
        Detect_respawn.respawned_clicked = false;

        
    }

    public void SaveData()
    {
        
    }    
   
    public void destroyObjects()
    {
        
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Spawnable"))
        {
            Destroy(o);
        }

        shirts = GameObject.FindGameObjectsWithTag("shirt");
        glasses = GameObject.FindGameObjectsWithTag("glasses");
        toothbrushes = GameObject.FindGameObjectsWithTag("toothbrush");
        houses = GameObject.FindGameObjectsWithTag("house");
        pencils = GameObject.FindGameObjectsWithTag("pencil");
        waters = GameObject.FindGameObjectsWithTag("water");
        chairs = GameObject.FindGameObjectsWithTag("chair");
        socks = GameObject.FindGameObjectsWithTag("socks");
        foreach (GameObject k in shirts)
        {
            k.GetComponent<DragDrop>().enabled = true;
        }
        foreach (GameObject k in glasses)
        {
            k.GetComponent<DragDrop>().enabled = true;
        }
        foreach (GameObject k in toothbrushes)
        {
            k.GetComponent<DragDrop>().enabled = true;
        }
        foreach (GameObject k in houses)
        {
            k.GetComponent<DragDrop>().enabled = true;
        }
        foreach (GameObject k in pencils)
        {
            k.GetComponent<DragDrop>().enabled = true;
        }
        foreach (GameObject k in waters)
        {
            k.GetComponent<DragDrop>().enabled = true;
        }
        foreach (GameObject k in chairs)
        {
            k.GetComponent<DragDrop>().enabled = true;
        }
        foreach (GameObject k in socks)
        {
            k.GetComponent<DragDrop>().enabled = true;
        }
    
    }

    IEnumerator Waiter(float delayTime)
    {
        UnityEngine.Debug.Log("In waiter before watiing for seconds");

        yield return new WaitForSeconds(delayTime);
        UnityEngine.Debug.Log("In waiter after watiing for seconds");
        shirts = GameObject.FindGameObjectsWithTag("shirt");
        glasses = GameObject.FindGameObjectsWithTag("glasses");
        toothbrushes = GameObject.FindGameObjectsWithTag("toothbrush");
        houses = GameObject.FindGameObjectsWithTag("house");
        pencils = GameObject.FindGameObjectsWithTag("pencil");
        waters = GameObject.FindGameObjectsWithTag("water");
        chairs = GameObject.FindGameObjectsWithTag("chair");
        socks = GameObject.FindGameObjectsWithTag("socks");

        foreach (GameObject k in shirts)
        {
            k.GetComponent<DragDrop>().enabled = false;
        }
        foreach (GameObject k in glasses)
        {
            k.GetComponent<DragDrop>().enabled = false;
        }
        foreach (GameObject k in toothbrushes)
        {
            k.GetComponent<DragDrop>().enabled = false;
        }
        foreach (GameObject k in houses)
        {
            k.GetComponent<DragDrop>().enabled = false;
        }
        foreach (GameObject k in pencils)
        {
            k.GetComponent<DragDrop>().enabled = false;
        }
        foreach (GameObject k in waters)
        {
            k.GetComponent<DragDrop>().enabled = false;
        }
        foreach (GameObject k in chairs)
        {
            k.GetComponent<DragDrop>().enabled = false;
        }
        foreach (GameObject k in socks)
        {
            k.GetComponent<DragDrop>().enabled = false;
        }
        UnityEngine.Debug.Log("In waiter after disabling scripts");

    }

    IEnumerator Waiter2(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        celebration.SetActive(false);
    }

}
