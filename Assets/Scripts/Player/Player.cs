using Game.Dialogue;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float mouseSensitivity = 3f;
    [SerializeField] float movementSpeed = 20f;
    [SerializeField] Transform cameraTransform;
    PlayerConversant playerConversant;

    private float rotationX = 0;
    CharacterController controller;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        playerConversant = gameObject.GetComponent<PlayerConversant>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        UpdateLook();
    }

    //Player movement
    void UpdateMovement()
    {
        if (playerConversant.GetCurrentDialogue() == null)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += Vector3.right * movementSpeed * Time.deltaTime;
            }
        }
    }


    //Mouse Look at x and y directions
    void UpdateLook()
    {
        if (playerConversant.GetCurrentDialogue() == null)
        {
            //Input.mousePosition.Set(0, 0, 0);
            rotationX -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            rotationX = Mathf.Clamp(rotationX, -90.0f, 90f);
            cameraTransform.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * mouseSensitivity, 0);
            
            /*look.y += Input.GetAxis("Mouse Y") * mouseSensitivity;
            look.y = Mathf.Clamp(look.y, -89f, 89f);

            cameraTransform.localRotation = Quaternion.Euler(-look.y, 0, 0);
            transform.localRotation = Quaternion.Euler(0, look.x, 0);*/
        }
    }
}
