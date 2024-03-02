using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDoorController : MonoBehaviour
{
    private Animator doorAnim;
    private bool doorOpen = false;

    private void Awake()
    {
        doorAnim = transform.root.gameObject.GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAnimation()
    {
        if (!doorOpen)
        {
            doorAnim.Play("door open", 0, 0.0f);
            doorOpen = true;
        }
        else
        {
            doorAnim.Play("door close", 0, 0.0f);
            doorOpen = false;
        }
    }
}
