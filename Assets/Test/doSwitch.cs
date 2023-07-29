using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSwitcher : MonoBehaviour
{
    private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        // get var status from script target in parent
        isActive = transform.parent.GetComponent<target>().status;
        
    }

    // Update is called once per frame
    void Update()
    {
                isActive = transform.parent.GetComponent<target>().status;

        // if is active, object is active if not is not active
        if (isActive){
            gameObject.SetActive(true);
        }else{
            gameObject.SetActive(false);
        }
    }


}
