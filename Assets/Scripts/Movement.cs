using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public static GameObject Light;

    public float multiplicador = 1;

    Rigidbody2D rig;


    // Start is called before the first frame update
    void Start()
    {
        Light = GameObject.FindWithTag("Player 1");

        rig =  GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.amAislado == true) return;

        float moverteclas= Input.GetAxis("Horizontal");

        //Falta el movimiento vertical
        //Esto es el movimiento base

        float midelta = Time.deltaTime;

        rig.velocity = new Vector3(moverteclas * multiplicador, rig.velocity.y);


    }

    
}
