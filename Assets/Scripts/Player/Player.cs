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
    SanitySystem playerSanitySystem;
    public float xOffset;
    public float zOffset = 0;
    public int HallwayNumber = 0;

    private float rotationX = 0;
    private float rotationY = 0;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        playerConversant = gameObject.GetComponent<PlayerConversant>();
        playerSanitySystem = gameObject.GetComponent<SanitySystem>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        UpdateLook();
        //SanityCheck();
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
        /*if (playerConversant.GetCurrentDialogue() == null)
        {
            //Input.mousePosition.Set(0, 0, 0);
            rotationX -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            rotationX = Mathf.Clamp(rotationX, -90.0f, 90f);
            cameraTransform.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * mouseSensitivity, 0);
        }*/
        if (playerConversant.GetCurrentDialogue() == null)
        {
            rotationX -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            rotationX = Mathf.Clamp(rotationX, -90.0f, 90.0f);

            rotationY += Input.GetAxis("Mouse X") * mouseSensitivity;
            rotationY = Mathf.Clamp(rotationY, -20.0f, 180.0f);

            cameraTransform.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation = Quaternion.Euler(0, rotationY, 0);
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Door")
        {
            Debug.Log("Player collided with door");
            gameObject.transform.position = new Vector3(0, 0, zOffset * HallwayNumber);
        }
    }

    public void SanityCheck()
    {
        if (playerSanitySystem.currentSanity <= 0)
        {
            //Game over Pop up
            GameObject.Find("Game UI").transform.Find("End Screen").gameObject.SetActive(true);
        }
        else if(playerSanitySystem.currentSanity <= 25)
        {
            //Fade in triggers and call the function to change the hallway
            if (HallwayNumber == 1)
            {
                HallwayNumber = 2;
                ChangeHallway();
            }
        }
        else if(playerSanitySystem.currentSanity <= 50)
        {
            //Fade out triggers and call the function to change the hallway
            if (HallwayNumber == 1)
            {
                HallwayNumber = 2;
                ChangeHallway();
            }
        }
        else if(playerSanitySystem.currentSanity <= 75)
        {
            //Fade out triggers and call the function to change the hallway
            if (HallwayNumber == 0)
            {
                HallwayNumber = 1;
                ChangeHallway();
            }
        }
    }

    void ChangeHallway()
    {
        gameObject.transform.position += new Vector3(xOffset, 0, zOffset);
    }
}
