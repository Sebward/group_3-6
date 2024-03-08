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
    public float finalSanity { get; set; }

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

    public void ModifyNegativeChoice(int amount) { negativeChoices += amount; }


    public void Start()
    {
        //startTime = System.DateTime.Now;

        sanitySystem = gameObject.GetComponent<SanitySystem>();
        completedGame = false;
    }

    public void Save()
    {
        //Debug.Log("Negative choices: " + negativeChoices);

        string path = Application.dataPath + "/Data/Playtest_" + System.DateTime.Now.Month + "_" + System.DateTime.Now.Day + "_" + System.DateTime.Now.Hour + "_" + System.DateTime.Now.Minute + ".txt";

        finalSanity = sanitySystem.getCurrentSanity();

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
    }

    public void SaveAndQuit()
    {
        StartCoroutine(SaveAndQuitTimed());
    }

    private IEnumerator SaveAndQuitTimed()
    {
        Save();
        yield return new WaitForSeconds(5f);
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void SetStartTime()
    {
        startTime = System.DateTime.Now;      
    }
}
