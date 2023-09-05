using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalHongoController : MonoBehaviour
{
     public GameObject comerHongo;

    private float  tiempoCrear = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempoCrear += Time.deltaTime;
        if(tiempoCrear >= 5f) {
            tiempoCrear = 0f;
            //Debug.Log("Correr izquierda :" + tiempoCrear); 
            Instantiate(comerHongo,transform.position,Quaternion.identity);
        }
    }
}
