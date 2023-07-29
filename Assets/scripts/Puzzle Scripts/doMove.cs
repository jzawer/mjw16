using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doMove : BaseAction
{
    private int direction = 1;
    private bool isActive = false;
    public float down = 1f;
    public float up = 1f;

    void Update()
    {
        if (isActive){
            if (transform.position.y < -down){
                direction = 1;
                Debug.Log("is moving down!");
            }else if (transform.position.y > up){
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
