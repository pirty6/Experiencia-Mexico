using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchNoche : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.GetComponent<Light>().enabled = false;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.GetComponent<Light>().enabled = true;
        }
    }
}
