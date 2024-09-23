using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuevoJugador : MonoBehaviour
{

    private float _velocidad;
    private Vector2 minPantalla;
    private Vector2 maxPantala;

    // Start is called before the first frame update
    void Start()
    {
        _velocidad = 8f;
        minPantalla = Camera.main.ViewportToWorldPoint( new Vector2(0, 0));
        maxPantala = Camera.main.ViewportToWorldPoint( new Vector2(1, 1));

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

        navePos.X = Mathf.Clamp(navePos.x , minPantalla.x, maxPantala.x);
        navePos.y = Mathf.Clamp(navePos.y, minPantalla.y, maxPantala.y);

        transform.position = navePos;
        

    }
}
