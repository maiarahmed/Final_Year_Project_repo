using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_imitator : MonoBehaviour
{
    public static GameObject[] tagged_shirt_slots ;
    public static GameObject[] tagged_water_slots;
    public static GameObject[] tagged_glasses_slots;
    public static GameObject[] tagged_toothbrush_slots;
    public static GameObject[] tagged_pencil_slots;
    public static GameObject[] tagged_chair_slots;
    public static GameObject[] tagged_house_slots;
    public static GameObject[] tagged_socks_slots;

    static GameObject shirt;
    public static Co_routine co_Routine = new Co_routine();
    public static float positionx;
    public static float positiony;

    public static float delayTime;
    private float weight_number_of_slots = 0.5f;
    private float weight_numberToSpawn = 2f;
    private float weight_timer = -0.2f;

    
    Collider2D shirt_collider;
    

    private void Start()
    {
        shirt = Resources.Load("shirt") as GameObject;
        shirt_collider = shirt.GetComponent<Collider2D>();
        shirt_collider.enabled = false;
        shirt_collider.enabled = true;
        //delayTime = 3f;
        
    }

    public void imitator()
    {
        Debug.Log("Number of slots " + Spawner.number_of_slots_history);
        Debug.Log("Numberto spawn " + Spawner.numberToSpawn_history);
        Debug.Log("Timer " + Timer.timer_controller);

        delayTime = (weight_numberToSpawn) * (Spawner.numberToSpawn_history + 1) 
            + (weight_number_of_slots) * (Spawner.number_of_slots_history + 1) 
            + (weight_timer) * (Timer.timer_controller);
        tagged_shirt_slots = GameObject.FindGameObjectsWithTag("shirt_slot");
        tagged_water_slots = GameObject.FindGameObjectsWithTag("water_slot");
        tagged_glasses_slots = GameObject.FindGameObjectsWithTag("glasses_slot");
        tagged_toothbrush_slots = GameObject.FindGameObjectsWithTag("toothbrush_slot");
        tagged_chair_slots = GameObject.FindGameObjectsWithTag("chair_slot");
        tagged_pencil_slots = GameObject.FindGameObjectsWithTag("pencil_slot");
        tagged_house_slots = GameObject.FindGameObjectsWithTag("house_slot");
        tagged_socks_slots = GameObject.FindGameObjectsWithTag("socks_slot");

        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");

        //shirt = Resources.Load("shirt") as GameObject;
        //Debug.Log("Before calling coroutine");
        Invoke("change_tags", delayTime);
        //co_Routine.Waiter(delayTime);
        Debug.Log("delaytime: " + delayTime);
        
    }

    private void change_tags()
    {
        foreach (GameObject i in tagged_shirt_slots)
        {
            if (i != null)
            {
                i.transform.tag = "Untagged";
            }
            //StartCoroutine(Waiter(delayTime));
        }
        foreach (GameObject i in tagged_water_slots)
        {
            if (i != null)
            {
                i.transform.tag = "Untagged";
            }
            //StartCoroutine(Waiter(delayTime));
        }
        foreach (GameObject i in tagged_glasses_slots)
        {
            if (i != null)
            {
                i.transform.tag = "Untagged";
            }
            //StartCoroutine(Waiter(delayTime));
        }
        foreach (GameObject i in tagged_toothbrush_slots)
        {
            if (i != null)
            {
                i.transform.tag = "Untagged";
            }
            //StartCoroutine(Waiter(delayTime));
        }
        foreach (GameObject i in tagged_chair_slots)
        {
            if (i != null)
            {
                i.transform.tag = "Untagged";
            }
            //StartCoroutine(Waiter(delayTime));
        }
        foreach (GameObject i in tagged_pencil_slots)
        {
            if (i != null)
            {
                i.transform.tag = "Untagged";
            }
            //StartCoroutine(Waiter(delayTime));
        }
        foreach (GameObject i in tagged_house_slots)
        {
            if (i != null)
            {
                i.transform.tag = "Untagged";
            }
            //StartCoroutine(Waiter(delayTime));
        }
        foreach (GameObject i in tagged_socks_slots)
        {
            if (i != null)
            {
                i.transform.tag = "Untagged";
            }
            //StartCoroutine(Waiter(delayTime));
        }

        if ((delayTime > 4) && (delayTime <= 9))
        {
            Debug.Log("THIS IS SUPPOSED TO BE A REWARD");
            //DDA_ML_agent dDA_ML_Agent = gameObject.AddComponent<DDA_ML_agent>();
            //dDA_ML_Agent.Rewards();
            GameObject Agent = GameObject.Find("ML_Agent");
            var agent = Agent.gameObject.GetComponent<DDA_ML_agent>();
            agent.AddReward(1f);
            agent.EndEpisode();
           
        }
        if (delayTime> 9)
        {
            Debug.Log("THIS IS SUPPOSED TO BE A PENALTY");
            //DDA_ML_agent dDA_ML_Agent = gameObject.AddComponent<DDA_ML_agent>();
            //dDA_ML_Agent.Rewards();
            GameObject Agent = GameObject.Find("ML_Agent");
            var agent = Agent.gameObject.GetComponent<DDA_ML_agent>();
            agent.AddReward(-1f);
            agent.EndEpisode();
        }
    }

    


}
