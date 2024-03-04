using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileIO : MonoBehaviour
{

    //Data to save
    private System.DateTime startTime;
    private bool completedGame;

    public void CreateText()
    {
        string path = Application.dataPath + "/Data/GameLogs.txt";

        if (!File.Exists(path))
        {
            File.WriteAllText(path, "Test \n");
        }

        string content = "Current Time" + System.DateTime.Now + "\n";

        File.AppendAllText(path, content);

        Debug.Log("FileIO is running");
    }

    public void Start()
    {
        startTime = System.DateTime.Now;
    }
}
