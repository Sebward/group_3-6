using UnityEngine;
using TMPro;
using UnityEngine.UI; // Include the UI namespace

public class SanityHUD : MonoBehaviour
{
    public SanitySystem playerSanitySystem; // Reference to the SanitySystem
    public Image sanityImage; // Reference to the UI element representing the sanity image
    public TMPro.TextMeshProUGUI sanityText; // Reference to the UI text element showing the current sanity number

    //these I just made for fun/testing
    public Sprite lowSanitySprite; // Sanity between 0% to 33%
    public Sprite mediumSanitySprite; // Sanity between 34% to 66%
    public Sprite highSanitySprite; // Sanity between 67% to 100%

    private void Start()
    {
        if (playerSanitySystem == null)
        {
            playerSanitySystem = GameObject.FindGameObjectWithTag("Player").GetComponent<SanitySystem>();
        }

        playerSanitySystem.OnSanityChanged += UpdateSanityDisplay;
    }

    private void UpdateSanityDisplay(float currentSanity)
    {
        int sanityPercentageInt = Mathf.RoundToInt((currentSanity / playerSanitySystem.maxSanity) * 100);

        // Update the sanity text
        sanityText.text = $"Sanity: {sanityPercentageInt}%";

        // Update the sanity image based on the current sanity percentage
        float sanityPercentage = (float)currentSanity / playerSanitySystem.maxSanity;

        if (sanityPercentage <= 0.33f)
        {
            sanityImage.sprite = lowSanitySprite;
        }
        else if (sanityPercentage <= 0.66f)
        {
            sanityImage.sprite = mediumSanitySprite;
        }
        else // Sanity is between 67% to 100%
        {
            sanityImage.sprite = highSanitySprite;
        }
    }

    private void OnDestroy()
    {
        playerSanitySystem.OnSanityChanged -= UpdateSanityDisplay;
    }
}