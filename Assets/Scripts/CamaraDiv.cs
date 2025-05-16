using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraDiv : MonoBehaviour
{
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();

        if (this.name == "Cam1")
        {
            cam.rect = new Rect(0f, 0f, 0.5f, 1.0f);
        }
        
        if (this.name == "Cam2")
        {
            cam.rect = new Rect(0.5f, 0f, 0.5f, 1.0f);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
