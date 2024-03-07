using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSounds : MonoBehaviour
{
    private SanitySystem sanitySystem;

    [Header("Random Sound Settings")]
    private bool startedRandomSounds = false;
    [SerializeField] float minInterval = 20.0f;
    [SerializeField] float maxInterval = 40.0f;

    void Start()
    {
        sanitySystem = GameObject.FindObjectOfType<SanitySystem>();
    }

    void Update()
    {
        if (!startedRandomSounds && sanitySystem.getCurrentSanity() < 50)
        {
            InvokeRepeating("PlayRandomSound", minInterval, maxInterval);
            startedRandomSounds = true;
        }
    }

    void PlayRandomSound()
    {
        SoundManager.Instance.PlayRandomSound();
    }

    public void StopRandomSounds()
    {
        CancelInvoke("PlayRandomSound");
    }
}
