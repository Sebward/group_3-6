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
            Debug.Log("Mouse over person");

            //Input
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Interacted with character");
                aIConversant.StartDialogue();
            }
        }
    }
}
