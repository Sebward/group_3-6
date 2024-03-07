using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileIO : MonoBehaviour
{
    //References
    SanitySystem sanitySystem;

    //Data to save
    private System.DateTime startTime;
    public bool completedGame;

    //Sanity Tracker
    private int finalSanity;

    //Total discussion count
    public int culverDisCount { get; set; }
    public int jennieDisCount { get; set; }
    public int lucyDisCount { get; set; }
    public int maryDisCount { get; set; }

    //Choice type selections
    public int positiveChoices { get; set; }
    public int neutralChoices { get; set; }
    public int negativeChoices { get; set; }


    public void Start()
    {
        startTime = System.DateTime.Now;

        sanitySystem = gameObject.GetComponent<SanitySystem>();
    }

    public void CreateText()
    {
        string path = Application.dataPath + "/Data/Playtest" + System.DateTime.Now +".txt";

        if (!File.Exists(path))
        {
            //Dialogue Setup
            string startTimeContent = "Start Time: " + startTime + "\n";
            string completedGameContent = "Completed Game?: " + completedGame + "\n";
            string finalSanityContent = "Final Sanity: " + finalSanity + "\n";

            string conversationCount = "Conversation Count Totals:\n" +
                "Dr. Culver: " + culverDisCount + "\n" +
                "Jennie: " + jennieDisCount + "\n" +
                "Lucy: " + lucyDisCount + "\n" +
                "Mary: " + maryDisCount + "\n";

            string choiceCount = "Conversation Type Selection Totals:\n" +
                "Positive Choices: " + positiveChoices + "\n" +
                "Neutral Choices: " + neutralChoices + "\n" +
                "Negative Choices: " + negativeChoices + "\n";


            string endTime = "End Time: " + System.DateTime.Now;

            File.WriteAllText(path, startTimeContent);
            File.AppendAllText(path, completedGameContent);
            File.AppendAllText(path, finalSanityContent);
            File.AppendAllText(path, conversationCount);
            File.AppendAllText(path, choiceCount);
            File.AppendAllText(path, endTime);
        } 
        //Debug.Log("FileIO is running");
    }

    public System.DateTime StartTime
    {
        set
        {
            startTime = System.DateTime.Now;
        }
    }

}
