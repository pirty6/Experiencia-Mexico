using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour {
    private bool mShowGUIButton = true;
    private Rect mButtonRect = new Rect(Screen.width - 60,20,24,24);
    public Texture texture;
    private Rect button1 = new Rect(270,140,200,50);
    private Rect button2 = new Rect(270, 210, 200, 50);
    private bool showButton = false;
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI() {
      if (mShowGUIButton) {
        GUI.DrawTexture(mButtonRect, texture);
        // draw the GUI button
        if (GUI.Button(mButtonRect, "", new GUIStyle())) {
          mShowGUIButton = false;
          showButton = true;
        }
      }

      if(showButton) {
        if(GUI.Button(button1, "Reiniciar")) {
          print("OWO");
        }
        if(GUI.Button(button2, "Regresar")) {
          showButton = false;
          mShowGUIButton = true;
        }
      }
    }
}
