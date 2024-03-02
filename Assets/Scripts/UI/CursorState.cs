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

    private CursorType cursorType = CursorType.Default;
    private Texture2D cursorTexture;
    private bool lockCursor = false;

    void Start()
    {
        SetCursorState(CursorType.Default);
    }

    public void SetCursorState(CursorType cursorType)
    {
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
