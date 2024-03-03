using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    GameManager gameManager;
    private List<GameObject> UIScreens = new List<GameObject>();
    private bool inMenu = true;

    void Start()
    {
        // Set up screens list
        foreach (Transform screen in gameObject.transform)
        {
            UIScreens.Add(screen.gameObject);

            if (screen.name == "Player Overlay")
            {
                foreach (Transform subscreen in screen.transform)
                {
                    UIScreens.Add(subscreen.gameObject);
                }
            }
        }

        // Get game manager
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        IsAnyMenuActive();
    }

    // Sets the given screen to active or inactive
    public void SetScreenActive(string screenName, bool setActive)
    {
        foreach (GameObject screen in UIScreens)
        {
            if (screen.name == screenName)
            {  
                screen.SetActive(setActive);
                return;
            }
        }

        Debug.Log("GameUI.cs: Screen " + screenName + " not found!");
    }

    // Helper method to SetScreenActive
    private void IsAnyMenuActive()
    {
        foreach (GameObject screen in UIScreens)
        {
            if (screen.activeSelf && screen.name.Contains("Screen"))
            {
                inMenu = true;
                return;
            }
        }

        inMenu = false;
    }

    public void SetAllMenusActive(bool setActive)
    {
        foreach (GameObject screen in UIScreens)
        {
            if (screen.activeSelf && screen.name.Contains("Screen"))
            {
                screen.SetActive(setActive);
            }
        }
    }

    public bool InMenu()
    {
        return inMenu;
    }

    // Returns a boolean whether the screen is active
    // Will return false if screeName is not found
    public bool IsScreenActive(string screenName)
    {
        foreach (GameObject screen in UIScreens)
        {
            if (screen.name == screenName)
            {
                return screen.activeSelf;
            }
        }

        Debug.Log("GameUI.cs: Screen " + screenName + " not found!");
        return false;
    }

    public void Restart()
    {
        gameManager.Restart();
    }

    public void Quit()
    {
        gameManager.Quit();
    }
}
