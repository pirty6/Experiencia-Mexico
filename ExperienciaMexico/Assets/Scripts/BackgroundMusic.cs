using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class BackgroundMusic : MonoBehaviour, ITrackableEventHandler {
  public AudioClip music;
  public AudioSource audioSource;
  private TrackableBehaviour mTrackableBehaviour;
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
               audioSource.clip = music;
               audioSource.Play();
      } else {
           // Stop audio when target is lost
           audioSource.Stop();
      }
  }

    // Update is called once per frame
    void Update()
    {

    }
}
