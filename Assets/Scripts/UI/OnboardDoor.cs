using Game.Dialogue;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnboardDoor : MonoBehaviour
{
    PlayerConversant playerConversant;
    // Start is called before the first frame update
    void Start()
    {
        playerConversant = FindObjectOfType<PlayerConversant>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerConversant.GetCurrentDialogue() != null) 
        {
            gameObject.tag = "OnboardingDoor";
        }
    }
}
