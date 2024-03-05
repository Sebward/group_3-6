using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Game.Dialogue;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private GameUI gameUI;
    private CursorState cursorState;
    private PlayerConversant playerConversant;
    private bool isPaused = false;
    
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
        playerConversant = GameObject.FindObjectOfType<PlayerConversant>();
    }

    void Update()
    {
        // Pause game if escape is pressed.
        // BREAKS MOUSE LOCK when ESC is pressed in Editor. -- Works fine in build!
        if (Input.GetKeyDown(KeyCode.Escape) && !gameUI.IsScreenActive("Start Screen"))
        {
            Pause();
        }
    }

    public void Pause()
    {
        isPaused =!isPaused;
        gameUI.SetScreenActive("Pause Screen", isPaused);
        if (!isPaused) gameUI.SetAllMenusActive(false);

        if (playerConversant != null && playerConversant.GetCurrentDialogue() != null)
        {
            cursorState.SetCursorLock(false);
        }
        else
        {
            cursorState.SetCursorLock(!isPaused);
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
