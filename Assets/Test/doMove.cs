using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSwitcher : MonoBehaviour
{
    private int direction = 1;
    private bool isActive = false;

    void Start()
    {
        isActive = transform.parent.GetComponent<target>().status;
    }

    void Update()
    {
        isActive = transform.parent.GetComponent<target>().status;

        if (isActive){
            if (transform.position.y < -2f){
                direction = 1;
                Debug.Log("is moving down!");
            }else if (transform.position.y > 2f){
                direction = -1;
                Debug.Log("is moving up!");
            }
            Debug.Log("is moving!");
            transform.position += Vector3.up * direction * Time.deltaTime;
        }
    }
}
