using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NuevoJugador : MonoBehaviour
{
    //VARIABLES
    private float _velocidad;
    private Vector2 minPantalla;
    private Vector2 maxPantalla;

    [SerializeField] private GameObject prefabProyectil;
    [SerializeField] private GameObject prefabExplocion;

    [SerializeField] private TMPro.TextMeshProUGUI TextNaveVides;

    private int vidasNave;



    // Start is called before the first frame update
    void Start()
    {

        _velocidad = 8f;

        maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));// abajo //izquierda
        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));// arriba //derecha

        float mitatdeimagenX = GetComponent<SpriteRenderer>().sprite.bounds.size.x * transform.localScale.x / 2;
        float mitatdeimagenY = GetComponent<SpriteRenderer>().sprite.bounds.size.x * transform.localScale.y / 2;

        minPantalla.x = minPantalla.x + mitatdeimagenX;
        maxPantalla.x = maxPantalla.x - mitatdeimagenX;
        minPantalla.y += mitatdeimagenY;
        maxPantalla.y -= mitatdeimagenY;

        vidasNave = 3;


    
}

    // Update is called once per frame
    void Update()
    {

        moureNave();

        DisparaProyectil();
        
        
    }
    private  void moureNave() // CARACTERISTICAS DE MOVIIENTO DE NAVE
    {
        float direccionIndicadaX = Input.GetAxisRaw("Horizontal");
        float direccionIndicadaY = Input.GetAxisRaw("Vertical");

        //Debug.Log("X :" + direccionIndicadaX + " - Y: " + direccionIndicadaY);

        Vector2 direccionIndicada = new Vector2(direccionIndicadaX, direccionIndicadaY).normalized;

        Vector2 navePos = transform.position;// posicion actual de la mavae con transfomr.position
        navePos = navePos + direccionIndicada * _velocidad * Time.deltaTime;
        //Debug.Log(Time.deltaTime); //

        //BORDES DE PANTALLA 
        navePos.x = Mathf.Clamp(navePos.x, minPantalla.x, maxPantalla.x);
        navePos.y = Mathf.Clamp(navePos.y, minPantalla.y, maxPantalla.y);

        transform.position = navePos;
    }

    

    private void DisparaProyectil()
    {
        if (Input.GetKeyDown("space")) // SI SE PRESIONA ESPACIO 
        {
            GameObject proyectil= Instantiate(prefabProyectil);
            proyectil.transform.position = transform.position;
        }

    }

    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if (objecteTocat.tag == "Numero")
        {
            vidasNave--;

            TextNaveVides.text = "vidas" + vidasNave.ToString();
            if (vidasNave == 0)
            {

                GameObject explocio = Instantiate(prefabExplocion);
                explocio.transform.position = transform.position;
                Destroy(gameObject);
                SceneManager.LoadScene("PantallaResultados");

                



            }
        }
    }


}
