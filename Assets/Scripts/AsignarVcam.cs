using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsignarVcam : MonoBehaviour
{

    public Cinemachine.CinemachineVirtualCamera myVCam;
    // Start is called before the first frame update
    void Start()
    {
        myVCam.Priority = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
