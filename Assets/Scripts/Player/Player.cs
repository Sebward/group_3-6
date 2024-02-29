using Game.Dialogue;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    //UI
    public GameObject startScreen;
    public GameObject dayUI;
    public GameObject playerUI;
    public GameObject clickUI;
    public GameObject mouseUI;
    public bool isHovering;

    private bool isLocked;
    private bool canMove;

    private float rotationX = 0;
    private float rotationY = 0;
    private FadeInOut fadeInOut;
    // Start is called before the first frame update
    void Start()
    {
        //UI and Mouse States
        Cursor.lockState = CursorLockMode.Confined;
        isLocked = false;
        isHovering = false;
        canMove = false;
        clickUI.transform.position = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0);
        mouseUI.transform.position = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0);

        playerConversant = gameObject.GetComponent<PlayerConversant>();
        playerSanitySystem = gameObject.GetComponent<SanitySystem>();
        fadeInOut = FindObjectOfType<FadeInOut>();
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
        //if (playerConversant.GetCurrentDialogue() == null)
        if (canMove)
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

    public void LockCursor()
    {
        if (isLocked)
        {
            Cursor.lockState = CursorLockMode.None;
            playerUI.SetActive(false);
            isLocked = false;
            canMove = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            playerUI.SetActive(true);
            HandUI();
            isLocked = true;
            canMove = true;
        }
    }

    public void HandUI()
    {
        if (isHovering)
        {
            clickUI.SetActive(true);
            mouseUI.SetActive(false);

        }
        else
        {
            clickUI.SetActive(false);
            mouseUI.SetActive(true);
        }
    }

    public void Intro()
    {
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
        LockCursor();
    }
}
