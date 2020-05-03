using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoom : MonoBehaviour {
  private RaycastHit hit;
  private bool mShowGUIButton = false;
  private Rect mButtonRect = new Rect(50,50,120,60);
  string button;
  int layerMask = (1 << 8);

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
      if(Input.GetMouseButton(0) || Input.GetMouseButtonDown(0)) {
          Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
          if (Physics.Raycast(ray, out hit, layerMask)) {
            Debug.Log("Touched object " + hit.transform.gameObject.name + " layer is " + hit.transform.gameObject.layer);
            button = hit.transform.name;
            print("Raycast hitted: " + hit.transform.name);
            switch(button) {
              case "mountain_capsule":
                print("OWO");
                GameObject.Find(button).transform.localScale = new Vector3(0, 0, 0);
                transform.localScale = new Vector3(50,50,50);
                mShowGUIButton = true;
                // button.enabled = false;
                break;
              case "ocean_button":
                GameObject.Find(button).transform.localScale = new Vector3(0, 0, 0);
                transform.localScale = new Vector3(50,50,50);
                mShowGUIButton = true;
                break;
              case "temple_button":
                GameObject.Find(button).transform.localScale = new Vector3(0, 0, 0);
                transform.localScale = new Vector3(50,50,50);
                mShowGUIButton = true;
                break;
              default:
                print(button);
                break;
            }
          }
      }

        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) {
          Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
          if (Physics.Raycast(ray, out hit, layerMask)) {
            button = hit.transform.name;
            switch(button) {
              case "mountain_button":
                GameObject.Find(button).transform.localScale = new Vector3(0, 0, 0);
                transform.localScale = new Vector3(50,50,50);
                mShowGUIButton = true;
                // button.enabled = false;
                break;
              case "ocean_button":
                GameObject.Find(button).transform.localScale = new Vector3(0, 0, 0);
                transform.localScale = new Vector3(50,50,50);
                mShowGUIButton = true;
                break;
              case "temple_button":
                GameObject.Find(button).transform.localScale = new Vector3(0, 0, 0);
                transform.localScale = new Vector3(50,50,50);
                mShowGUIButton = true;
                break;
              default:
                break;
            }
          }
        }
    }

  void OnGUI() {
    if (mShowGUIButton) {
      // draw the GUI button
      if (GUI.Button(mButtonRect, "Regresar")) {
        transform.localScale = new Vector3(15,15,15);
        GameObject.Find(button).transform.localScale = new Vector3(0.06717828f, 0.06717828, 0.06717828f);
        mShowGUIButton = false;
      }
    }
  }
}
