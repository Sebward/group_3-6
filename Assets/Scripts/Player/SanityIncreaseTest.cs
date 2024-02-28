using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectIncreaseSanity : MonoBehaviour
{
    public float effectRadius = 5f; // The radius within which the object affects the player's sanity
    public float sanityDecreaseAmount = 0.5f; // The amount by which to decrease the player's sanity
    private GameObject player; // Reference to the player GameObject
    private SanitySystem playerSanitySystem; // Reference to the player's SanitySystem component

    void Start()
    {
        // Find the player GameObject by tag, assuming the player GameObject is tagged as "Player"
        player = GameObject.FindGameObjectWithTag("Player");
        // Get the SanitySystem component from the player GameObject
        if (player != null)
        {
            playerSanitySystem = player.GetComponent<SanitySystem>();
        }
    }

    void Update()
    {
        // Check if the player is within the effect radius
        if (Vector3.Distance(player.transform.position, transform.position) <= effectRadius)
        {
            // Decrease the player's sanity
            playerSanitySystem?.ModifySanity(+sanityDecreaseAmount);
        }
    }
}