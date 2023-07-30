using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    //public gameobject spainpoint
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // rotate object if key  q is pressed
        if (Input.GetKeyDown(KeyCode.Q)){
            transform.Rotate(0, -90, 0);
        }else if (Input.GetKeyDown(KeyCode.E)){
            transform.Rotate(0, 90, 0);
        }
        
    }
}
