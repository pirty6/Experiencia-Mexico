using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Video;

public class zoom_teotihuacan : MonoBehaviour, ITrackableEventHandler {
  public AudioClip[] aClips;
  public AudioSource audioSource;
  public AudioSource background;

  private TrackableBehaviour mTrackableBehaviour;

  private RaycastHit hit;
  private bool mShowGUIButton = false;
  private Rect mButtonRect = new Rect(50,50,120,60);
  string button;
  string[] sarray = {"sun_temple_capsule", "moon_temple_capsule", "other_temple_capsule"};
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
      // Script = GameObject.Find("theObjectName").GetComponent<ItemsScript>();
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
             if(active != null) {
               active.GetComponent<VideoPlayer>().Stop();
             }
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
              case "sun_temple_capsule":
                x = 0;
                z = 0;
                transform.localScale = new Vector3(50,50,50);
                mShowGUIButton = true;
                audioSource.clip = aClips[0];
                active = GameObject.Find("VideoMajorTemple");
                active.transform.localScale = new Vector3(76.55721f, 39.1688f, 0.5404546f);
                active.GetComponent<VideoPlayer>().Play();
                //audioSource.Play();
                // button.enabled = false;
                break;
              case "moon_temple_capsule":
                transform.localScale = new Vector3(50,50,50);
                mShowGUIButton = true;
                audioSource.clip = aClips[1];
                //audioSource.Play();
                x = -0.1f;
                z = 0.45f;
                GameObject.Find("Teotihuacan").transform.localPosition = new Vector3(x,0,z);
                active = GameObject.Find("VideoMinorTemple");
                active.transform.localScale = new Vector3(76.55721f, 39.1688f, 0.5404546f);
                active.GetComponent<VideoPlayer>().Play();
                break;
              case "other_temple_capsule":
                transform.localScale = new Vector3(50,50,50);
                x = 0.5f;
                z = 0.40f;
                GameObject.Find("Teotihuacan").transform.localPosition = new Vector3(x,0,z);
                mShowGUIButton = true;
                active = GameObject.Find("VideoOtherTemple");
                active.transform.localScale = new Vector3(76.55721f, 39.1688f, 0.5404546f);
                active.GetComponent<VideoPlayer>().Play();
                // audioSource.clip = aClips[2];
                // audioSource.Play();
                break;
              default:
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
              case "sun_temple_capsule":
                x = 0;
                z = 0;
                transform.localScale = new Vector3(50,50,50);
                mShowGUIButton = true;
                audioSource.clip = aClips[0];
                active = GameObject.Find("VideoMajorTemple");
                active.transform.localScale = new Vector3(76.55721f, 39.1688f, 0.5404546f);
                active.GetComponent<VideoPlayer>().Play();
                //audioSource.Play();
                // button.enabled = false;
                break;
              case "moon_temple_capsule":
                transform.localScale = new Vector3(50,50,50);
                mShowGUIButton = true;
                audioSource.clip = aClips[1];
                //audioSource.Play();
                x = -0.1f;
                z = 0.45f;
                GameObject.Find("Teotihuacan").transform.localPosition = new Vector3(x,0,z);
                active = GameObject.Find("VideoMinorTemple");
                active.transform.localScale = new Vector3(76.55721f, 39.1688f, 0.5404546f);
                active.GetComponent<VideoPlayer>().Play();
                break;
              case "other_temple_capsule":
                transform.localScale = new Vector3(50,50,50);
                x = 0.5f;
                z = 0.40f;
                GameObject.Find("Teotihuacan").transform.localPosition = new Vector3(x,0,z);
                mShowGUIButton = true;
                active = GameObject.Find("VideoOtherTemple");
                active.transform.localScale = new Vector3(76.55721f, 39.1688f, 0.5404546f);
                active.GetComponent<VideoPlayer>().Play();
                // audioSource.clip = aClips[2];
                // audioSource.Play();
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
        GameObject.Find("Teotihuacan").transform.localPosition = new Vector3(0,0,0);
        transform.localScale = new Vector3(15,15,15);
        audioSource.Stop();
        active.transform.localScale = new Vector3(0,0,0);
        active.GetComponent<VideoPlayer>().Stop();
        mShowGUIButton = false;
      }
    }
  }
}
