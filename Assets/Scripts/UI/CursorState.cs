using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CursorType
{
    Default,
    DefaultHover,
    Dot,
    DoorInteract,
    DialogueInteract
}

public class CursorState : MonoBehaviour
{
    [SerializeField] private Texture2D[] textures;

    private GameUI gameUI;
    private CursorType cursorType = CursorType.Default;
    private Texture2D cursorTexture;
    private bool lockCursor = false;
    private bool lockState = false;

    void Start()
    {
        gameUI = GameObject.FindObjectOfType<GameUI>();
        SetCursorState(CursorType.Default);
    }

    void Update()
    {
        // Flags to change and lock cursor STATE if in menu
        if (cursorType != CursorType.Default && gameUI.InMenu())
        {
            SetCursorState(CursorType.Default);
            lockState = true;
        }
        else if (!gameUI.InMenu())
        {
            lockState = false;
        }
    }

    public void SetCursorState(CursorType cursorType)
    {
        if (lockState) return;
        this.cursorType = cursorType;
        this.cursorTexture = textures[(int)cursorType];
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    public CursorType GetCursorState()
    {
        return cursorType;
    }

    public void SetCursorLock(bool isLocked)
    {
        lockCursor = isLocked;

        if (isLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
