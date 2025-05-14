using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamPlay : MonoBehaviour
{

    public Transform target;

    public Vector3 offset = new Vector3(0, 0,-10f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset;

        }

    }
}
