using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTransform;


    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {

        //We store current camera's position
        Vector3 temp = transform.position;

        //set camera's x to player's x
        temp.x = playerTransform.position.x;
        if(temp.x > 17.3)
        {
            temp.x = 17.3f;
        }
        if(temp.x < 0.1)
        {
            temp.x = 0.1f;
        }

        temp.y = playerTransform.position.y;
        if(temp.y < 0)
        {
            temp.y = 0;
        }

        transform.position = temp;
    }
}
