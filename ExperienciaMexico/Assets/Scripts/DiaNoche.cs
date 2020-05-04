using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DiaNoche : MonoBehaviour
{
    public Vector3 rotacionDia = new Vector3 (90, 180, 0);
    public Vector3 rotacionNoche = new Vector3(45, -80, 0);
    public float intensidadDia = 1;
    public float intensidadNoche = 0.5f;
    public Vector4 colorDia = new Vector4(255, 255, 255, 255);
    public Vector4 colorNoche = new Vector4(225, 233, 255, 255);
    Transform sol;
    Light luzSol;
    bool dia = true;
    void AplicaCambio() {
        
        if (dia)
        {
            sol.rotation = Quaternion.Euler(90, 180, 0);
            //luzSol.intensity = 0.01f;
            luzSol.color = new Vector4(255, 255, 255, 255);

        }
        else
        {
            sol.rotation = Quaternion.Euler(45, -80, 0);
           // luzSol.intensity = 0.001f;
            luzSol.color = new Vector4(225, 233, 255, 255);

        }


    }

    // Start is called before the first frame update
    void Start()
    {
        
        sol = GameObject.Find("Sol").GetComponent<Transform>();
        luzSol = GameObject.Find("Sol").GetComponent<Light>();
        AplicaCambio();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            dia = !dia;
            AplicaCambio();
        }
    }
}
