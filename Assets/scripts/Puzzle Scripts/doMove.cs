using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class doMove : BaseAction
{
    private int direction = 1;
    private bool isActive = false;
    private bool isMoving = false;
    public float down = 1f;
    public float up = 1f;

    void Update()
    {
        if (isActive){
            if (transform.localPosition.y < down) {
                direction = 1;
                Debug.Log("is moving down!");
            }else if (transform.localPosition.y > up){
                direction = -1;
                Debug.Log("is moving up!");
            }
            Debug.Log("is moving!");
            
            transform.localPosition += Vector3.up * direction * Time.deltaTime;
        }
    }

    public override void DoAction()
    {
        isActive = transform.parent.GetComponent<target>().status;
    }
}
