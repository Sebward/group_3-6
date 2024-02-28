using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private GameUI gameUI;
    
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
    }

    void Update()
    {
        // Pause game if escape is pressed.
        if (Input.GetKeyDown(KeyCode.Escape) && !gameUI.IsScreenActive("Start Screen"))
        {
            gameUI.SetScreenActive("Pause Screen", !gameUI.IsScreenActive("Pause Screen"));
        }
    }

    public void Restart()
    {
        // Assumes only one scene -- update here otherwise!
        SceneManager.LoadScene("TogetherScene");

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
