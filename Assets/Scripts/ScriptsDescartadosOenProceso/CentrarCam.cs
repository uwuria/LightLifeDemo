using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentrarCam : MonoBehaviour
{

    GameObject posP1;
    GameObject posP2;
    // Start is called before the first frame update
    void Start()
    {
        posP1 = GameObject.FindGameObjectWithTag("Player 1");

        posP2 = GameObject.FindGameObjectWithTag("Player 2");


    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (posP1.transform.position + posP2.transform.position) / 2;
    }
}
