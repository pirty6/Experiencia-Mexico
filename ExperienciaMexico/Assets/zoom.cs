using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class zoom : MonoBehaviour, ITrackableEventHandler {
  public AudioClip[] aClips;
  public AudioSource audioSource;

  private TrackableBehaviour mTrackableBehaviour;

  private RaycastHit hit;
  private bool mShowGUIButton = false;
  private Rect mButtonRect = new Rect(50,50,120,60);
  string button;
  string[] sarray = {"mountain_capsule", "ocean_capsule", "temple_capsule"};
  int layerMask = (1 << 8);

    // Start is called before the first frame update
    void Start() {
      mTrackableBehaviour = GetComponent<TrackableBehaviour>();
      if (mTrackableBehaviour) {
        mTrackableBehaviour.RegisterTrackableEventHandler(this);
      }
    }

    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus) {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {
			           // Play audio when target is found
                 audioSource.clip = aClips[3];
                 audioSource.Play();
        } else {
			       // Stop audio when target is lost
			       audioSource.Stop();
        }
    }

    // Update is called once per frame
    void Update() {
      if(Input.GetMouseButton(0) || Input.GetMouseButtonDown(0)) {
          Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
          if (Physics.Raycast(ray, out hit, layerMask)) {
            button = hit.transform.name;
            print("Raycast hitted: " + hit.transform.name);
            switch(button) {
              case "mountain_capsule":
                // GameObject.Find(button).transform.localScale = new Vector3(0, 0, 0);
                transform.localScale = new Vector3(50,50,50);
                mShowGUIButton = true;
                audioSource.clip = aClips[0];
                audioSource.Play();
                // button.enabled = false;
                break;
              case "ocean_capsule":
                // GameObject.Find(button).transform.localScale = new Vector3(0, 0, 0);
                transform.localScale = new Vector3(50,50,50);
                mShowGUIButton = true;
                audioSource.clip = aClips[1];
                audioSource.Play();
                break;
              case "temple_capsule":
                // GameObject.Find(button).transform.localScale = new Vector3(0, 0, 0);
                transform.localScale = new Vector3(50,50,50);
                mShowGUIButton = true;
                audioSource.clip = aClips[2];
                audioSource.Play();
                break;
              default:
                print(button);
                break;
            }
          }
      }

        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) {
          Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
          if (Physics.Raycast(ray, out hit, layerMask)) {
            button = hit.transform.name;
            print("Raycast hitted: " + hit.transform.name);
            switch(button) {
              case "mountain_capsule":
                // GameObject.Find(button).transform.localScale = new Vector3(0, 0, 0);
                transform.localScale = new Vector3(50,50,50);
                mShowGUIButton = true;
                // button.enabled = false;
                break;
              case "ocean_capsule":
                // GameObject.Find(button).transform.localScale = new Vector3(0, 0, 0);
                transform.localScale = new Vector3(50,50,50);
                mShowGUIButton = true;
                break;
              case "temple_capsule":
                // GameObject.Find(button).transform.localScale = new Vector3(0, 0, 0);
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
        // for(int i = 0; i < 3; i++) {
        //   GameObject.Find(sarray[i]).transform.localScale = new Vector3(0.06717828f, 0.06717828f, 0.06717828f);
        // }
        audioSource.Stop();
        mShowGUIButton = false;
      }
    }
  }
}
