using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explocion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestruirExplicon", 1f); // al 1 segundo utiliza el metodo destruir 
    }

    private void DestruirExplicon()//metodo para destruir nave
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
