using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Timer : MonoBehaviour
{
    //intialise all objects, variables, lists and arrays
    public float timeRemaining;
    public bool timerIsRunning = false;
    public Text timeText;
    public Component[] slots;
    public static List<int> dda_memory = new List<int>();
    private int hold;
    private bool respawn;
    public static bool respawn_button_clicked = false;
    public static long reaction_time = 0;
    public static int timer_controller;
    public static float timer_history;
    private GameObject[] spawnable_objects;
    public Image timerbar;
    public GameObject celebration;
    public ParticleSystem particlesystem;
    public GameObject[] shirts;
    public GameObject[] toothbrushes;
    public GameObject[] socks;
    public GameObject[] pencils;
    public GameObject[] glasses;
    public GameObject[] chairs;
    public GameObject[] houses;
    public GameObject[] waters;
    private void Start()
    {
        // Starts the timer automatically at 5 seconds duration
        timerIsRunning = true;
        timer_controller = 5;

    }
    void Update()
    {
        //Find respawn button by its name
        Button Respawn_button = GameObject.Find("Respawn_button").GetComponent<Button>();
        //Create an on click listener function which activates when respawn button is clicked.
        Respawn_button.onClick.AddListener(TaskOnClick);
        
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
                timerbar.fillAmount = timeRemaining/timer_controller;

            }
                

            else
            {
               
                timeRemaining = 0;
                timerIsRunning = false;

                Spawner spawner = new Spawner();
                spawner.destroyObjects();

            }
        }

        //Continously check if all slots are untagged (meaning the player got all items correct)
        GameObject slots = GameObject.Find("slots");
        int i = slots.transform.childCount;
        int j = 0;
        int count = 0;

        while (j < i)
        {
            GameObject child = slots.transform.GetChild(j).gameObject;
            if (child.tag == "Untagged")
            {
                count++;
            }
            j++;
        }

        float delayTime = 1f;
        // test if all slots are untagged
        if ((count == i) && (Spawner.respawned == false))
        {
            
            dda_memory.Add(1);
            
            hold = 1;

            Spawner.timer_bool = false;

            
            Spawner.reaction_time = 0;
            
            spawnable_objects = GameObject.FindGameObjectsWithTag("Spawnable");
            foreach(GameObject k in spawnable_objects)
            {
                Destroy(k);
            }

            if (Detect_respawn.respawned_clicked == false)
            {
                Debug.Log("respawned_clicked from inside timer function " + Detect_respawn.respawned_clicked);
                celebration_function();
            }
            
            Respawn_button.onClick.Invoke();
            
        }
        
        if((SlotHandler.detect_drop == 1) && (count != i) && (hold != 1))
        {
            dda_memory.Add(-1);
            
        }
        SlotHandler.detect_drop = 0;
        hold = 0;
    }

    void Respawn_function()
    {
        Button Respawn_button = GameObject.Find("Respawn_button").GetComponent<Button>();
        Respawn_button.onClick.Invoke();
    }

    void celebration_function()
    {
        celebration.SetActive(true);
        particlesystem.Play(true);
        StartCoroutine(waiter(2f));
    }
    IEnumerator waiter(float delayTime)
    {
        
        yield return new WaitForSeconds(delayTime);
        Debug.Log("In coroutine for celebration");
        celebration.SetActive(false);
        particlesystem.Play(false);
  
    }


    void TaskOnClick()
    {
        respawn_button_clicked = true;

        if (DDA_ML_agent.change_timer > 3)
        {
            timer_controller = DDA_ML_agent.change_timer;
        }
        else if (DDA_ML_agent.change_timer < 3)
        {
            timer_controller = 3;
        }
        timer_history = timer_controller;
        
        timeRemaining = timer_controller;
        timerIsRunning = true;
        respawn = true;

        GameObject slots = GameObject.Find("slots");
        int i = slots.transform.childCount;
        int j = 0;

        while (j < i)
        {
            GameObject child = slots.transform.GetChild(j).gameObject;
            if (child.tag != "Untagged")
            {
                child.tag = "Untagged";
            }
            j++;
        }
        
        respawn = false;
        
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
