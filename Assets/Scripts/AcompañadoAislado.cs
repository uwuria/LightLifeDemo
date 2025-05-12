using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcompañadoAislado : MonoBehaviour
{

    

    Vector3 posIn;

    GameObject posPlayer2;
    // Start is called before the first frame update
    void Start()
    {
        posIn = this.transform.position;

        posPlayer2 = GameObject.FindGameObjectWithTag("Player 2");
    }

    // Update is called once per frame
    void Update()
    {
        // Esto es para saber la distancia entre jugadores
        float distancia = Vector3.Distance(transform.position, posPlayer2.transform.position);


        //mecanica Aislado, falta acompañado y añadir las luces y tambien programar la obtencion de estos items
        if (distancia > 9.68f || distancia < -9.68f)
        {

            
            GameManager.amAislado = true;

        }
    }
}
