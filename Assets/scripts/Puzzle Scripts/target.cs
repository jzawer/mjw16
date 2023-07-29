using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    public bool status = false;

    public void doTargetAction()
    {
        status = !status;

        foreach (Transform child in transform)
        {

            child.GetComponent<BaseAction>().DoAction();
        }
        
    }

}
