using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuevoJugador : MonoBehaviour
{

    private float _velocidad;
    private Vector2 minPantalla;
    private Vector2 maxPantalla;

    // Start is called before the first frame update
    void Start()
    {
       
        _velocidad = 8f;
      
        maxPantalla = Camera.main.ViewportToWorldPoint( new Vector2(1, 1));// abajo //izquierda
        minPantalla = Camera.main.ViewportToWorldPoint( new Vector2(0, 0));// arriba //derecha

        float mitatdeimagenX = GetComponent<SpriteRenderer>().sprite.bounds.size.x * transform.localScale.x / 2;
        float mitatdeimagenY = GetComponent<SpriteRenderer>().sprite.bounds.size.x * transform.localScale.y / 2;

        minPantalla.x = minPantalla.x + mitatdeimagenX;
        maxPantalla.x = maxPantalla.x - mitatdeimagenX;
        minPantalla.y += mitatdeimagenY;
        maxPantalla.y -= mitatdeimagenY;

        
        

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

        //BORDES DE PANTALLA 
        navePos.x = Mathf.Clamp(navePos.x , minPantalla.x, maxPantalla.x);
        navePos.y = Mathf.Clamp(navePos.y, minPantalla.y, maxPantalla.y);

        transform.position = navePos;
        
        
    }
}
