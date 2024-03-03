using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private GameUI gameUI;
    private CursorState cursorState;
    private bool paused;
    
    void Start()
    {
        // Set up game manager.
        if (instance == null)
        {
            // Makes gamemanager persistent.
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Prevents duplicate instances of the game manager.
            Destroy(gameObject);
        }

        // Set up GameUI reference.
        gameUI = GameObject.FindObjectOfType<GameUI>();
        cursorState = GameObject.FindObjectOfType<CursorState>();
    }

    void Update()
    {
        // Pause game if escape is pressed.
        if (Input.GetKeyDown(KeyCode.P) && !gameUI.IsScreenActive("Start Screen"))
        {
            paused = !paused;

            if (paused)
            {
                // Show pause screen and disable lock.
                gameUI.SetScreenActive("Pause Screen", true);
                cursorState.SetCursorLock(false);
            }
            else
            {
                // Hide all menus (including pause) and enable lock.
                gameUI.SetAllMenusActive(false);
                cursorState.SetCursorLock(true);
            }     

            cursorState.SetCursorState(CursorType.Default);   
        }
    }

    public void Restart()
    {
        // Assumes only one scene -- update here otherwise!
        SceneManager.LoadScene(0);

        // Find new references since scene was updated.
        Start();
    }

    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
