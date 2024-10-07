using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilJugador : MonoBehaviour
{
    // Start is called before the first frame update

    //VARIABLE
    private float _vel;
    private Vector2 MaxPantalla;



    void Start()
    {
        _vel = 10f; //velocidad 

        MaxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        
}

    // Update is called once per frame
    void Update()
    {
        Vector2 posiInicial = transform.position;

        posiInicial = posiInicial + new Vector2(0,1) * _vel * Time.deltaTime;

        transform.position = posiInicial;

        if (transform.position.y > MaxPantalla.y){

            Destroy(gameObject);

        }
        

    }
    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if (objecteTocat.tag == "Numero")
        {
            Destroy(gameObject);

        }
    }

}
