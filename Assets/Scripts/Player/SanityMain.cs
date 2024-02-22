using System;
using UnityEngine;

public class SanitySystem : MonoBehaviour
{
    public float maxSanity = 100.0f;
    private float currentSanity;

    // Event triggered when sanity changes.
    public event Action<float> OnSanityChanged;

    private void Start()
    {
        // Initialize player's sanity.
        currentSanity = maxSanity;
    }

    public void ModifySanity(float amount)
    {
        currentSanity += amount;
        currentSanity = Mathf.Clamp(currentSanity, 0, maxSanity);

        // Trigger the sanity changed event.
        OnSanityChanged?.Invoke(currentSanity);
        CheckSanityLevelEvents();
        Debug.Log(currentSanity);
    }

    // return current sanity level || might be redundant
    public float getCurrentSanity()
    {
        return this.currentSanity;
    }

    private void CheckSanityLevelEvents()
    {
        // Trigger events based on sanity level.
        // These are just an example
        if (currentSanity < 20)
        {
            // Trigger low sanity event.
        }
        else if (currentSanity > 80)
        {
            // Trigger high sanity event.
        }
    }
}