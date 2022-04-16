using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : m_CameraController
{
    // Start is called before the first frame update
    void Start()
    {
        target = null;
        //set target to player
        //target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            try
            {
                target = GameObject.FindGameObjectWithTag("Player").transform;
            }

            catch
            {
                Debug.Log("nothing to find");
            }
            
        
            //change camera postion to target's postion
            
        }

        else
        {
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -25f);
        }
    }
}
