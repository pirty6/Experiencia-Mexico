using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroy : MonoBehaviour {
    // Start is called before the first frame update
    void Awake() {
      GameObject fuji = GameObject.Find("ImageTarget_Fuji");
      DontDestroyOnLoad(fuji);
    }
}
