using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Game.UI
{
    public class DropdownHandler : MonoBehaviour
    {
        private TMP_Dropdown dropdown;
        [SerializeField] DialogueUI dialogueUI;

        void Start()
        {
            dropdown = gameObject.GetComponent<TMP_Dropdown>();
        }

        public void ChangeTextSpeed()
        {
            if (dialogueUI == null) return;

            switch (dropdown.value)
            {
                case 0:
                    dialogueUI.SetTextSpeed(0.02f);
                    break;
                case 1:
                    dialogueUI.SetTextSpeed(0.008f);
                    break;
                case 2:
                    dialogueUI.SetTextSpeed(0.032f);
                    break;
            }
        }
    }
}
