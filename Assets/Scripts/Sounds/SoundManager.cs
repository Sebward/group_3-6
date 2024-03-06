using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    [SerializeField] float intialSFXVolume = 0.8f;

    public static SoundManager Instance
    {
        get
        {
            // Try to find instance in the scene if not found
            if (instance == null)
            {
                instance = FindObjectOfType<SoundManager>();

                // If it's still null, create a new instance
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject("SoundManager");
                    instance = singletonObject.AddComponent<SoundManager>();
                }
            }

            return instance;
        }
    }

    void Start()
    {
        // Ensure there's only one instance
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        // Initalize audio source
        audioSource = gameObject.AddComponent<AudioSource>();

        // Set inital volume
        audioSource.volume = intialSFXVolume;
    }

    [SerializeField] AudioClip[] soundClips;
    private AudioSource audioSource;

    public void PlaySound(int soundIndex)
    {
        if (soundIndex >= 0 && soundIndex < soundClips.Length)
        {
            audioSource.PlayOneShot(soundClips[soundIndex]);
        }
        else
        {
            Debug.LogWarning("Invalid sound index: " + soundIndex);
        }
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public float GetVolume()
    {
        return audioSource.volume;
    }
}