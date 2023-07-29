using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    // array of gameobjects
    public GameObject[] objectsToSwitch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // when the player enter the trigger switch the variable isActive in the script ActiveSwitcher of the objects
    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Player"){
            foreach (GameObject obj in objectsToSwitch){
                obj.GetComponent<target>().doTargetAction();
            }
        }
    }
}
