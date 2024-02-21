using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Dialogue
{
    public class AIConversant : MonoBehaviour
    {
        PlayerConversant playerConversant;
        [SerializeField] Dialogue dialogue = null;
        [SerializeField] string conversantName = "";
        [SerializeField] Sprite conversantSprite;

        void Start()
        {
            playerConversant = GameObject.FindObjectOfType<PlayerConversant>();
        }

        public string GetName()
        {
            return conversantName;
        }

        public void SetName(string newName)
        {
            conversantName = newName;
        }

        public Sprite GetConversantSprite()
        {
            return conversantSprite;
        }

        public void StartDialogue()
        {
            playerConversant.StartDialogue(this, dialogue);
        }
    }
}
