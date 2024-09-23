using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuevoJugador : MonoBehaviour
{

    private float _velocidad;

    // Start is called before the first frame update
    void Start()
    {
        _velocidad = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        float direccionIndicadaX = Input.GetAxisRaw("Horizontal");
        float direccionIndicadaY = Input.GetAxisRaw("Vertical");
        //Debug.Log("X :" + direccionIndicadaX + " - Y: " + direccionIndicadaY);
        Vector2 direccionIndicada = new Vector2(direccionIndicadaX, direccionIndicadaY).normalized;
        
        Vector2 navePos = transform.position;// posicion actual de la mavae con transfomr.position
        navePos = navePos + direccionIndicada * _velocidad * Time.deltaTime;
        //Debug.Log(Time.deltaTime); //

        transform.position = navePos;
        

    }
}
