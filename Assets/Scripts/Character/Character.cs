using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Dialogue
{
    public class Character : MonoBehaviour
    {
        AIConversant aIConversant;
        Player player;

        void Awake()
        {
            aIConversant = gameObject.GetComponent<AIConversant>();
            player = GameObject.Find("Player").GetComponent<Player>() as Player;
        }

        void OnMouseEnter()
        {
            player.isHovering = true;
            player.HandUI();
        }

        private void OnMouseOver()
        {
            //Input
            if (Input.GetKeyDown(KeyCode.E))
            {
                aIConversant.StartDialogue();
                player.LockCursor();
            }
        }

        void OnMouseExit()
        {
            player.isHovering = false;
            player.HandUI();
        }
    }
}
