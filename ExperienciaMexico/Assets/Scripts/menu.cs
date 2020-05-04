using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour {
    private bool mShowGUIButton = true;
    private Rect mButtonRect = new Rect(Screen.width - 60,20,24,24);
    public Texture texture;
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI() {
      GUI.DrawTexture(mButtonRect, texture);
      if (mShowGUIButton) {
        // draw the GUI button
        if (GUI.Button(mButtonRect, "", new GUIStyle())) {
          print("hewwo");
        }
      }
    }
}
