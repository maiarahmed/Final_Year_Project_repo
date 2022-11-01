using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Scripting.Python;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using System.IO;


public class Story_Line : MonoBehaviour
{
    public float speed = camera_controller.speed;
    //public static List<GameObject> assetpool = new List<GameObject>();
    public List<GameObject> assetpool; //= spawner_speech_game.objects;
    public GameObject objectincentre; 
    private Vector3 memory;
    private int slotnumber;
    public TextMeshProUGUI name_of_item;
    public string name;
    public AudioSource item_sound;
    private bool runVAD = false;
    public float threshold = 0.01f;
    public static bool playing_audio = false;

    public bool dont_play_on_startup = false;
    public GameObject speechobjects;

    // Start is called before the first frame update
    void Start()
    {
        //Generate a random number to randomly shuffle the order of appearance of assets
        
        Debug.Log(assetpool.Count);
        Button continue_button = GameObject.Find("continue_button").GetComponent<Button>();
        continue_button.onClick.AddListener(TaskOnClick);
        speed = 0f;

    //Recording();
    }

    private void Update()
    {
        /*if (runVAD == true)
        {
            VAD();
            runVAD = false;
        }*/

        if (VAD_redirect.counter_VAD >=1 )
        {
            objectincentre = GameObject.FindGameObjectWithTag("centre");
            item_sound = assetpool[slotnumber].GetComponent<AudioSource>();
            item_sound.Play();
        }

    }
    // Update is called once per frame
    void Recording()
    {
        //memory = assetpool[5].transform.position;
        
        microphone.MicrophoneToAudioClip();
        
        AudioSource audioSource = GameObject.Find("MicrophoneInput").GetComponent<AudioSource>();

        float loudness = microphone.GetLoudnessFromMicrophone();

        Debug.Log("loudness of clip: " + loudness);
        if (loudness < threshold)
        {
            loudness = 0;
        }

        else if (loudness > threshold)
        {
            Debug.Log("Loud enough");
        }
        Button continue_button = GameObject.Find("continue_button").GetComponent<Button>();
        //continue_button.onClick.Invoke();

    }
    void TaskOnClick()
    {

        //Remove the object that was in the centre to its original position
        objectincentre = GameObject.FindGameObjectWithTag("centre");
        objectincentre.transform.position = memory;
        objectincentre.transform.tag = "Untagged";
        //text.text = "";
        Debug.Log("In task on click 1");
        //Drag another item from the assetpool to the centre
        slotnumber = Random.Range(1, assetpool.Count);
        memory = assetpool[slotnumber].transform.position;
        //assetpool[slotnumber].transform.localScale = new Vector2(150, 150);
        assetpool[slotnumber].transform.position = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width / 2) - 450, (Screen.height / 2) - 100, Camera.main.nearClipPlane));
        VAD_redirect.counter_VAD = 0;
        //assetpool[slotnumber].transform.SetParent(speechobjects.transform);
        speed = 0f;
        assetpool[slotnumber].transform.tag = "centre";
        name_of_item.text = assetpool[slotnumber].GetComponent<Text>().text.ToString();
        if (assetpool[slotnumber].GetComponent<AudioSource>() != null)
        {
            item_sound = assetpool[slotnumber].GetComponent<AudioSource>();
            Debug.Log("item sound: " + item_sound);
            playing_audio = true;
            item_sound.Play();
            playing_audio = false;
            
        }

        dont_play_on_startup = false;

        Debug.Log("In task on click 2");
        runVAD = true;

        Button record_button = GameObject.Find("Record").GetComponent<Button>();
        //record_button.onClick.Invoke();
        //VAD_redirect.VAD();
        //StartCoroutine(Example());
        // runVAD = false;
        //VAD();

        //Recording();
        //Debug.Log("The name of the item: " + name_of_item);
        //Debug.Log(assetpool[slotnumber].GetComponent<TextMesh>().text);

        //Store original position of asset in memory

        //assetpool[slotnumber].transform.position = new Vector3(0,350,0);


    }

    /*void VAD()
    {
        string scriptPath = Path.Combine(Application.dataPath, "test.py");
        Debug.Log("VAD runner functional");
        PythonRunner.RunFile(scriptPath);
    }*/

    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(2);
        print(Time.time);
    }
}
