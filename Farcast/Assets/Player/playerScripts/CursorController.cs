using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{

    public playerGeneral player; //player
    public CursorControls controls; //input controller

    public Texture2D cursor;
    public Texture2D dialogueCursor;
    public Texture2D mineCursor;
    private Vector2 cursorHotspot;

    public bool AttackPressed = false;
    public bool InteractPressed = false;

    public void Awake()
    {
        player = new playerGeneral();
        controls = new CursorControls();
        
        Cursor.lockState = CursorLockMode.Confined; //confines cursor to game window
        cursorHotspot = new Vector2(cursor.width / 2, cursor.height / 2);
        changeCursor(cursor);
    }

    public void LateUpdate()
    {
        AttackPressed = false;
        InteractPressed = false;
    }

    //cursor appearances
    private void changeCursor(Texture2D cursorType) 
    {
        Cursor.SetCursor(cursorType, cursorHotspot, CursorMode.Auto);
    }


    //disable and enable
    void OnEnable()
    {
        controls.Mouse.Attack.performed += _ => AttackPressed = true;
        controls.Mouse.Interact.performed += _ => InteractPressed = true;
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }
}
