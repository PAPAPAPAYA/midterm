using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guiscript : MonoBehaviour
{
    public Texture2D cursorIMG;
    public int cursorX = 16;
    public int cursorY = 16;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI() {
        Event e = Event.current;
        Debug.Log(e.mousePosition);

        GUI.DrawTexture(new Rect(Event.current.mousePosition.x - cursorX/2,
                                 Event.current.mousePosition.y - cursorY/2, cursorX, cursorY), cursorIMG);
    }
}
