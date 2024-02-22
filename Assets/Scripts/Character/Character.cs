using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Dialogue
{
    public class Character : MonoBehaviour
    {
        AIConversant aIConversant;

        void Start()
        {
            aIConversant = gameObject.GetComponent<AIConversant>();
        }

        private void OnMouseOver()
        {
            //Input
            if (Input.GetKeyDown(KeyCode.E))
            {
                aIConversant.StartDialogue();
            }
        }
    }
}
