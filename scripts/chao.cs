using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chao : MonoBehaviour
{

     public float diferencax;
     public float minx;

    private void Update()
    {
        if (transform.position.x <= minx) 
        {
            transform.position = new Vector3
            (
                transform.position.x + diferencax * 2,
                transform.position.y,
                transform.position.z
            );
        }
    }

}
