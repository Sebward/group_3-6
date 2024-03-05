using Game.Dialogue;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    //[SerializeField] float mouseSensitivity = 3f;
    private Vector3 PlayerMovementInput;
    /*private Vector2 PlayerMouseInput;
    private float xRot;*/
    [SerializeField] private float mouseSensitivity;
    [SerializeField] float speed;
    [SerializeField] private Rigidbody rb;
    [SerializeField] Transform cameraTransform;
    PlayerConversant playerConversant;
    SanitySystem playerSanitySystem;
    public bool InConversation = false;
    public float xOffset;
    public float zOffset = 0;
    public int HallwayNumber = 0;

    // Cursor
    CursorState cursorState;

    //UI
    public GameObject startScreen;
    public GameObject dayUI;

    private float rotationX = 0;
    private float rotationY = 0;
    private FadeInOut fadeInOut;

    // Start is called before the first frame update
    void Start()
    {
        //UI and Mouse States
        playerConversant = gameObject.GetComponent<PlayerConversant>();
        playerSanitySystem = gameObject.GetComponent<SanitySystem>();
        fadeInOut = FindObjectOfType<FadeInOut>();
        cursorState = FindObjectOfType<CursorState>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        UpdateMovement();
        UpdateLook();
        //SanityCheck();
    }

    //Player movement
    void UpdateMovement()
    {
        if (playerConversant.GetCurrentDialogue() == null)
        {
            Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput) * speed;
            rb.velocity = new Vector3(MoveVector.x, rb.velocity.y, MoveVector.z);
        }
    }


    //Mouse Look at x and y directions
    void UpdateLook()
    {
        if (playerConversant == null || playerConversant.GetCurrentDialogue() == null)
        {
            InConversation = false;
            rotationX -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            rotationX = Mathf.Clamp(rotationX, -90.0f, 90.0f);

            rotationY += Input.GetAxis("Mouse X") * mouseSensitivity;
            //rotationY = Mathf.Clamp(rotationY, -20.0f, 180.0f);

            cameraTransform.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation = Quaternion.Euler(0, rotationY, 0);
        }
        else
        {
            //cameraTransform.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            Vector3 currentRotation = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z);
            //Debug.Log(currentRotation);
            //transform.rotation = Quaternion.Euler(0, currentRotation.y, 0);

            if(!InConversation)
            {
                transform.rotation = Quaternion.Euler(0, currentRotation.y, 0);
                InConversation = true;
            }
        }
    }

/*    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Door")
        {
            Debug.Log("Player collided with door");
            gameObject.transform.position = new Vector3(0, 0, zOffset * HallwayNumber);
        }
    }*/

    public void SanityCheck()
    {
        if (playerSanitySystem.currentSanity <= 0)
        {
            //Game over Pop up
            cursorState.SetCursorLock(false);
            GameObject.Find("Game UI").transform.Find("End Screen").gameObject.SetActive(true);
        }
        else if(playerSanitySystem.currentSanity <= 25)
        {
            //Fade in triggers and call the function to change the hallway
            if (HallwayNumber == 2)
            {
                HallwayNumber = 3;
                StartCoroutine(Fade());
            }
        }
        else if(playerSanitySystem.currentSanity <= 50)
        {
            //Fade out triggers and call the function to change the hallway
            if (HallwayNumber == 1)
            {
                HallwayNumber = 2;
                StartCoroutine(Fade());
            }
        }
        else if(playerSanitySystem.currentSanity <= 75)
        {
            //Fade out triggers and call the function to change the hallway
            if (HallwayNumber == 0)
            {
                Debug.Log("Sanity is 75");
                HallwayNumber = 1;
                StartCoroutine(Fade());
            }
        }
    }

    void ChangeHallway()
    {
        gameObject.transform.position += new Vector3(xOffset, 0, zOffset);
    }

    public void ResetHallway()
    {
        gameObject.transform.position = new Vector3(0, 2, zOffset * HallwayNumber);
    }

    public void Intro()
    {
        cursorState.SetCursorLock(true);
        StartCoroutine(IntroEnum());
    }

    public IEnumerator Fade()
    {
        fadeInOut.FadeIn();
        //yield return new WaitForSeconds(3);
        ChangeHallway();
        yield return new WaitForSeconds(3);
        fadeInOut.FadeOut();
    }

    private IEnumerator IntroEnum()
    {
        fadeInOut.FadeIn();
        yield return new WaitForSeconds(1.5f);
        //Set text to active
        startScreen.SetActive(false);
        dayUI.SetActive(true);
        yield return new WaitForSeconds(2f);
        //Deactivate text
        dayUI.SetActive(false);
        //Reset location
        yield return new WaitForSeconds(0.5f);
        fadeInOut.FadeOut();
        cursorState.SetCursorState(CursorType.Default);
    }
}
