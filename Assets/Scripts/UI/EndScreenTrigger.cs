using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndScreenTrigger : MonoBehaviour
{
    [SerializeField] GameObject endScreen;
    [SerializeField] GameObject dayUI;
    [SerializeField] TMP_Text dayText;
    Player player;
    DayTracker dayTracker;
    private int dayMax;

    private FadeInOut fadeInOut;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>() as Player;
        dayTracker = GameObject.Find("DayTracker").GetComponent<DayTracker>() as DayTracker;
        fadeInOut = FindObjectOfType<FadeInOut>();

        dayMax = 3;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            if(dayMax == dayTracker.Day)
            {
                endScreen.SetActive(true);
            }
            else
            {
                dayTracker.NewDay();
                dayText.text = "Day " + dayTracker.Day;
                StartCoroutine(Fade());
            }
        }
    }

    public IEnumerator Fade()
    {
        fadeInOut.FadeIn();

        yield return new WaitForSeconds(0.5f);

        //Set text to active
        dayUI.SetActive(true);   

        yield return new WaitForSeconds(1.8f);

        //Deactivate text
        dayUI.SetActive(false);
        //Reset location
        player.ResetHallway();

        yield return new WaitForSeconds(0.2f);

        fadeInOut.FadeOut();
    }
}
