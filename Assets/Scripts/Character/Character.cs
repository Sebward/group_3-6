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
        CursorState cursorState;
        Player player;


/*        //Data Points
        [SerializeField] 
        public string characterName;*/


        void Awake()
        {
            playerConversant = GameObject.FindObjectOfType<PlayerConversant>();
            aIConversant = gameObject.GetComponent<AIConversant>();
            gameUI = GameObject.FindObjectOfType<GameUI>();
            player = GameObject.Find("Player").GetComponent<Player>() as Player;
            cursorState = GameObject.FindObjectOfType<CursorState>();
        }

        private void OnMouseOver()
        {
            // Show interaction text if dialogue isn't active
            if (playerConversant.GetCurrentDialogue() == null)
            {
                cursorState.SetCursorState(CursorType.DialogueInteract);
                gameUI.SetScreenActive("Interact Popup", true);
            }

            //Input
            if (Input.GetKeyDown(KeyCode.E))
            {
                aIConversant.StartDialogue();
                cursorState.SetCursorState(CursorType.Default);
                gameUI.SetScreenActive("Interact Popup", false);
            }
        }

        private void OnMouseExit()
        {
            cursorState.SetCursorState(CursorType.Default);
            gameUI.SetScreenActive("Interact Popup", false);           
        }
    }
}
