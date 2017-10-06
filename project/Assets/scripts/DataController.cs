using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;
using System;

public class DataController : MonoBehaviour
{

    private string gameDataFileName = "data.json";

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        LoadGameData();

    }

    private void LoadGameData()
    {
        // Path.Combine combines strings into a file path
        // Application.StreamingAssets points to Assets/StreamingAssets in the Editor, and the StreamingAssets folder in a build
        string filePath = Path.Combine(Application.dataPath, gameDataFileName);
        Debug.Log(filePath);

        if (File.Exists(filePath))
        {
            // Read the json from the file into a string
            string dataAsJson = File.ReadAllText(filePath);
            // Pass the json to JsonUtility, and tell it to create a GameData object from it
            MyClass p = new MyClass();
            p = JsonUtility.FromJson<MyClass>(dataAsJson);

            Debug.Log(p.names[9]);
            //Debug.Log(p.happy[2]);
           
        }
        else
        {
            Debug.LogError("Cannot load game data!");
        }
    }

}

[Serializable]
public class MyClass
{
    public string[] names;
    public string[] happy;


}