using System.Collections;
using System.Collections.Generic;
using System.Data;
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
        if(AcompañadoAislado.amAislado == true){
            rig.velocity = Vector2.zero;
            return;
        } 
        else
        {
            float moverHoriz= Input.GetAxis("Horizontal");
            float moverVert= Input.GetAxis("Vertical");

        
            //Esto es el movimiento base

            float midelta = Time.deltaTime;

            //rig.velocity = new Vector3(moverHoriz * multiplicador, rig.velocity.y);

            //rig.velocity = new Vector3(rig.velocity.x, moverVert * multiplicador);
 
 
            rig.velocity = new Vector3(moverHoriz * multiplicador, moverVert * multiplicador);
        }
    }

    
}
