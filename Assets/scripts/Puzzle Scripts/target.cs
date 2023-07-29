using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    public bool status = false;

    private void Start()
    {
        ExecuteActionOnChildren();
    }

    public void doTargetAction()
    {
        status = !status;

        ExecuteActionOnChildren();
    }

    private void ExecuteActionOnChildren()
    {
        foreach (Transform child in transform)
        {

            child.GetComponent<BaseAction>().DoAction();
        }
    }

}
