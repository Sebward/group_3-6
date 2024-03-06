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

    public void PlayAnimation()
    {
        if (!doorOpen)
        {
            doorAnim.Play("door open", 0, 0.0f);
            SoundManager.Instance.PlaySound(0);
            doorOpen = true;
        }
        else
        {
            doorAnim.Play("door close", 0, 0.0f);
            SoundManager.Instance.PlaySound(1);
            doorOpen = false;
        }
    }
}
