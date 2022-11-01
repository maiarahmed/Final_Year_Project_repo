using System.Collections;
using System.Collections.Generic;
using UnityEditor.Scripting.Python;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor;

public class VAD_redirect : MonoBehaviour
{
    public TextAsset file;
    public static int speech;
    public static bool in_VAD;
    public static bool dont_play_on_startup = false;
    public static int counter_VAD;

    [System.Serializable]

    public class Speech
    {
        public string speaking;
    }

    [System.Serializable]

    public class speechList
    {
        public Speech[] speech;
    }

    //public speechList mySpeechList = new speechList();
    public void Start()
    {
        //Button record_button = GameObject.Find("Record").GetComponent<Button>();
        //record_button.onClick.AddListener(VAD);
        //VAD();
        dont_play_on_startup = true;
        //mySpeechList = JsonUtility.FromJson<speechList>(file.text);

        string path = "Assets/speech.txt";
        readTextFile(path);

        StreamWriter writer = new StreamWriter(path, false);
        writer.Write(0);
        writer.Close();
        readTextFile(path);

    }

    public void Update()
    {
        if (in_VAD == false)
        {
            VAD();
        }
    }

    public void read_json()
    {
        //mySpeechList = JsonUtility.FromJson<speechList>(file.text);
        //JsonUtility.FromJsonOverwrite(file.text, mySpeechList); 
        //mySpeechList = JsonUtility.FromJson<speechList>(file.text);
    }
    public static void VAD()
    {
        in_VAD = true;
        string scriptPath = Path.Combine(Application.dataPath, "test.py");
        Debug.Log("VAD runner functional");
        PythonRunner.RunFile(scriptPath);
        counter_VAD = counter_VAD + 1;
        //read_json();
        //EditorJsonUtility.FromJsonOverwrite(file.text, mySpeechList);
        string path = "Assets/speech.txt";
        readTextFile(path);

        if (speech == 1)
        {
            Button continue_button = GameObject.Find("continue_button").GetComponent<Button>();
            continue_button.onClick.Invoke();

            StreamWriter writer = new StreamWriter(path, false);
            writer.Write(0);
            writer.Close();
            readTextFile(path);
        }
        in_VAD = false;
        dont_play_on_startup = false;
    }

    public static void readTextFile(string file_path)
    {
        StreamReader reader = new StreamReader(file_path);

        while (!reader.EndOfStream)
        {
            string data = reader.ReadLine();
            speech = int.Parse(data);
            // Do Something with the input. 
        }

        reader.Close();
    }
}
