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
    public int culverDisCount;
    private void ModifyCulverCount(int amount) { culverDisCount += amount; }


    public int jennieDisCount;
    private void ModifyJennieCount(int amount) { jennieDisCount += amount; }


    public int lucyDisCount;
    private void ModifyLucyCount(int amount) { lucyDisCount += amount; }


    public int maryDisCount;
    private void ModifyMaryCount(int amount) { maryDisCount += amount; }


    //Choice type selections
    private int positiveChoices;
    public void ModifyPositiveChoice(int amount) { positiveChoices += amount; }

    private int neutralChoices;
    public void ModifyNeutralChoice(int amount) { neutralChoices += amount; }

    private int negativeChoices; 
    public void ModifyNegativeChoice(int amount) { negativeChoices += amount; Debug.Log("Negative choices Test: " + negativeChoices); }


    public void Start()
    {
        startTime = System.DateTime.Now;

        sanitySystem = gameObject.GetComponent<SanitySystem>();
        completedGame = false;
    }

    public void CreateText()
    {
        Debug.Log("Negative choices: " + negativeChoices);

        string path = Application.dataPath + "/Data/Playtest" + 2 +".txt";

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
