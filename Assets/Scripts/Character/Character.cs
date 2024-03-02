using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Dialogue
{
    public class Character : MonoBehaviour
    {
        PlayerConversant playerConversant;
        AIConversant aIConversant;
        GameUI gameUI;
        Player player;

        void Awake()
        {
            playerConversant = GameObject.FindObjectOfType<PlayerConversant>();
            aIConversant = gameObject.GetComponent<AIConversant>();
            gameUI = GameObject.FindObjectOfType<GameUI>();
            player = GameObject.Find("Player").GetComponent<Player>() as Player;
        }

        void OnMouseEnter()
        {
            
        }

        private void OnMouseOver()
        {
            // Show interaction text if dialogue isn't active
            if (playerConversant.GetCurrentDialogue() == null)
            {
                gameUI.SetScreenActive("Interact Popup", true);
            }

            //Input
            if (Input.GetKeyDown(KeyCode.E))
            {
                aIConversant.StartDialogue();
                gameUI.SetScreenActive("Interact Popup", false);
            }
        }

        private void OnMouseExit()
        {
            gameUI.SetScreenActive("Interact Popup", false);           
        }
    }
}
