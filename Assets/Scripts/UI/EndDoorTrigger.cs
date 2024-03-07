using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDoorTrigger : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] GameObject YellowGlow;
    [SerializeField] GameObject WhiteGlow;
    SanitySystem playerSanitySystem;
    // Start is called before the first frame update
    void Start()
    {
        playerSanitySystem = GameObject.FindObjectOfType<SanitySystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (playerSanitySystem.currentSanity >= 30)
            {
                WhiteGlow.SetActive(true);
                door.SetActive(true);
                Debug.Log("Player entered end door trigger");
                door.GetComponent<MyDoorController>().PlayAnimation();
            }
            else
            {
                YellowGlow.SetActive(true);
                door.SetActive(true);
                Debug.Log("Player entered end door trigger");
                door.GetComponent<MyDoorController>().PlayAnimation();
            }
        }
    }
}
