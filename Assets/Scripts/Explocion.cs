using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explocion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestruirExplicon", 1f);
    }

    private void DestruirExplicon()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
