using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenTrigger : MonoBehaviour
{
    [SerializeField] GameObject endScreen;

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            endScreen.SetActive(true);
        }
    }
}
