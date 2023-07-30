using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doSwitch : BaseAction
{

    public override void DoAction()
    {
                FindObjectOfType<AudioManager>().Play("button");

        status = transform.parent.GetComponent<target>().status;

        gameObject.SetActive(status);
    }

}
