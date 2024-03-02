using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;

    private MyDoorController rayCastedObj;
    /*private bool doOnce;*/

    [SerializeField] private KeyCode openDoorKey = KeyCode.E;
    private const string doorTag = "OnboardingDoor";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
            if (hit.collider.CompareTag(doorTag))
            {
                rayCastedObj = hit.collider.gameObject.GetComponent<MyDoorController>();
                if(Input.GetKeyDown(openDoorKey))
                {
                    rayCastedObj.PlayAnimation();
                }
            }
        }
    }
}
