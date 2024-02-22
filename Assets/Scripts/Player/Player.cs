using Game.Dialogue;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{

    [SerializeField] float mouseSensitivity = 3f;
    [SerializeField] float movementSpeed = 20f;
    [SerializeField] Transform cameraTransform;
    PlayerConversant playerConversant;

    Vector2 look;
    CharacterController controller;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
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
            look.x += Input.GetAxis("Mouse X") * mouseSensitivity;
            look.y += Input.GetAxis("Mouse Y") * mouseSensitivity;

            look.x = Mathf.Clamp(look.x, -45f, 240f);
            look.y = Mathf.Clamp(look.y, -89f, 89f);

            cameraTransform.localRotation = Quaternion.Euler(-look.y, 0, 0);
            transform.localRotation = Quaternion.Euler(0, look.x, 0);
        }
    }
}
