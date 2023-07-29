using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public GameObject spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        // Raycast to check if is a block in front of the player
        
       /*  if (!Physics.Raycast(transform.position + transform.forward, Vector3.down, 1)){
            Debug.Log("There is nothing in DOWN / FRONT of the object!");
        }
        if (!Physics.Raycast(transform.position - transform.forward, Vector3.down, 1)){
            Debug.Log("There is nothing in DOWN / BACK of the object!");
        } */
        
        if (transform.position.y < -0.01f){
            if (transform.position.y < -10){
                transform.position = spawnPoint.transform.position;
                transform.rotation = Quaternion.identity;
            }
        }else if (Input.GetKeyDown(KeyCode.W)){
            movePlayer(1);
        }else if (Input.GetKeyDown(KeyCode.S)){
            movePlayer(-1);
        }else if (Input.GetKeyDown(KeyCode.A)){
            transform.Rotate(0, -90, 0);
        }else if (Input.GetKeyDown(KeyCode.D)){
            transform.Rotate(0, 90, 0);
        }
    }
    // create function to move player
    void movePlayer(int direction){

        RaycastHit hitMove;
        RaycastHit hitWall;
        RaycastHit hitEmpty;

        if (Physics.Raycast(transform.position + transform.up, transform.forward * direction, out hitWall, 1) && (Physics.Raycast(transform.position, transform.forward * direction, out hitMove, 1))){
            Debug.Log("is hitting a wall!");
            if (hitWall.collider.gameObject.tag == "Portal"){
                Debug.Log("is hitting a portal!");
                transform.position = hitWall.collider.gameObject.GetComponent<portal>().spawnPoint.transform.position;
            }
        }else if (Physics.Raycast(transform.position, transform.forward * direction, out hitMove, 1)){
            transform.position += transform.forward * direction; 
            transform.position += transform.up;
        }else if (!Physics.Raycast(transform.position + transform.forward * direction, Vector3.down, out hitEmpty, 1)){
            Debug.Log("is falling!");
            transform.position += transform.forward * direction;
        }else{
            transform.position += transform.forward * direction;
        }
    }

}

