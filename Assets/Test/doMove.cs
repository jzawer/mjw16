using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSwitcher : BaseAction
{
    private int direction = 1;
    private bool isActive = false;


    void Update()
    {
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

    public override void DoAction()
    {
        isActive = transform.parent.GetComponent<target>().status;
    }
}
