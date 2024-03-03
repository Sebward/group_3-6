using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;


    private MyDoorController rayCastedObj;
    private CursorState cursorState;
    GameUI gameUI;
    /*private bool doOnce;*/

    [SerializeField] private KeyCode openDoorKey = KeyCode.E;
    private const string doorTag = "OnboardingDoor";

    void Start()
    {
        cursorState = GameObject.FindObjectOfType<CursorState>();
        gameUI = GameObject.FindObjectOfType<GameUI>();
    }

    void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
            if (hit.collider.CompareTag(doorTag))
            {
                cursorState.SetCursorState(CursorType.DoorInteract);
                gameUI.SetScreenActive("Interact Popup", true);
                rayCastedObj = hit.collider.gameObject.GetComponent<MyDoorController>();
                if(Input.GetKeyDown(openDoorKey))
                {
                    rayCastedObj.PlayAnimation();
                }
            }
        }
        else
        {
            if (cursorState.GetCursorState() == CursorType.DoorInteract)
            {
                cursorState.SetCursorState(CursorType.Default);
                gameUI.SetScreenActive("Interact Popup", false);
            }
        }
    }
}
