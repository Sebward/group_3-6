using System;
using UnityEngine;
using Game.Core;

public class SanitySystem : MonoBehaviour, IPredicateEvaluator
{
    public float maxSanity = 100.0f;
    public float currentSanity;

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

    // Evaluator for dialogue system condition.
    public bool? Evaluate(eCondition predicate, string[] parameters)
    {
        if (predicate == eCondition.PlayerSanityGreaterThan)
        {
            return currentSanity >= int.Parse(parameters[0]);
        }

        if (predicate == eCondition.PlayerSanityLessThan)
        {
            return currentSanity <= int.Parse(parameters[0]);
        }

        if (predicate == eCondition.PlayerSanityEqualTo)
        {
            return currentSanity == int.Parse(parameters[0]);
        }

        // Otherwise, the requested predicate is not supported. -- Return null.
        return null;
    }
}