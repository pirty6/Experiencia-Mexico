using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Video;

public class zoom : MonoBehaviour, ITrackableEventHandler {
  public AudioClip[] aClips;
  public AudioSource audioSource;
  public AudioSource background;

  private TrackableBehaviour mTrackableBehaviour;

  private RaycastHit hit;
  private bool mShowGUIButton = false;
  private Rect mButtonRect = new Rect(50,50,120,60);
  string button;
  string[] sarray = {"mountain_capsule", "ocean_capsule", "temple_capsule"};
  int layerMask = (1 << 8);
  float x = 0;
  float z = 0;
  GameObject active;

    // Start is called before the first frame update
    void Start() {
      background.loop = true;
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
                 background.PlayOneShot(aClips[4]);
        } else {
			       // Stop audio when target is lost
			       audioSource.Stop();
             background.Stop();
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
                x = -0.1f;
                z = 0.1f;
                // GameObject.Find(button).transform.localScale = new Vector3(0, 0, 0);
                transform.localScale = new Vector3(50,50,50);
                mShowGUIButton = true;
                audioSource.clip = aClips[0];
                //audioSource.Play();
                GameObject.Find("Fuji").transform.localPosition = new Vector3(x,0,z);
                active = GameObject.Find("VideoMountain");
                active.transform.localScale = new Vector3(0.01116154f, 0.005942067f, 0.0001076876f);
                active.GetComponent<VideoPlayer>().Play();
                // button.enabled = false;
                break;
              case "ocean_capsule":
                // GameObject.Find(button).transform.localScale = new Vector3(0, 0, 0);
                x = -0.6f;
                z = -0.7f;
                transform.localScale = new Vector3(50,50,50);
                mShowGUIButton = true;
                audioSource.clip = aClips[1];
                audioSource.Play();
                GameObject.Find("Fuji").transform.localPosition = new Vector3(x,0,0.3f);
                break;
              case "temple_capsule":
                // GameObject.Find(button).transform.localScale = new Vector3(0, 0, 0);
                x = 0.1f;
                z = -0.5f;
                transform.localScale = new Vector3(50,50,50);
                mShowGUIButton = true;
                audioSource.clip = aClips[2];
                //audioSource.Play();
                GameObject.Find("Fuji").transform.localPosition = new Vector3(x,0,z);
                active = GameObject.Find("VideoTemple");
                active.transform.localScale = new Vector3(0.01116154f, 0.005942067f, 0.0001076876f);
                active.GetComponent<VideoPlayer>().Play();
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
                x = -0.1f;
                z = 0.1f;
                // GameObject.Find(button).transform.localScale = new Vector3(0, 0, 0);
                transform.localScale = new Vector3(50,50,50);
                mShowGUIButton = true;
                audioSource.clip = aClips[0];
                //audioSource.Play();
                GameObject.Find("Fuji").transform.localPosition = new Vector3(x,0,z);
                // button.enabled = false;
                break;
              case "ocean_capsule":
                // GameObject.Find(button).transform.localScale = new Vector3(0, 0, 0);
                x = -0.6f;
                z = -0.7f;
                transform.localScale = new Vector3(50,50,50);
                mShowGUIButton = true;
                audioSource.clip = aClips[1];
                audioSource.Play();
                GameObject.Find("Fuji").transform.localPosition = new Vector3(x,0,0.3f);
                break;
              case "temple_capsule":
                // GameObject.Find(button).transform.localScale = new Vector3(0, 0, 0);
                x = 0.1f;
                z = -0.5f;
                transform.localScale = new Vector3(50,50,50);
                mShowGUIButton = true;
                audioSource.clip = aClips[2];
                audioSource.Play();
                GameObject.Find("Fuji").transform.localPosition = new Vector3(x,0,z);
                break;
              default:
                print(button);
                break;
            }
          }
        }
    }

  void OnGUI() {
    if (mShowGUIButton) {
      // draw the GUI button
      if (GUI.Button(mButtonRect, "Regresar")) {
        GameObject.Find("Fuji").transform.localPosition = new Vector3(0,0,0);
        transform.localScale = new Vector3(22.0687f,22.0687f,22.0687f);
        audioSource.Stop();
        active.transform.localScale = new Vector3(0,0,0);
        active.GetComponent<VideoPlayer>().Stop();
        mShowGUIButton = false;
      }
    }
  }
}
