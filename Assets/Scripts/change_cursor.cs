using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_cursor : MonoBehaviour
{

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void change_to_sword()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }
}
