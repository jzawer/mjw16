using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class player : MonoBehaviour
{
    const string IS_FALLING = "isFalling";
    const string IS_MOVING = "isMoving";

    public GameObject spawnPoint;
    private Animator? _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
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

        _animator?.SetBool(IS_MOVING, false);
        if (transform.position.y < -0.01f){
            if (transform.position.y < -10){
                _animator?.SetBool(IS_FALLING, false);
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

        _animator?.SetBool(IS_MOVING, true);

        if (Physics.Raycast(transform.position + transform.up, transform.forward * direction, out hitWall, 1) && (Physics.Raycast(transform.position, transform.forward * direction, out hitMove, 1))){
            Debug.Log("is hitting a wall!");
            if (hitWall.collider.gameObject.tag == "Portal"){
                Debug.Log("is hitting a portal!");
                transform.position = hitWall.collider.gameObject.GetComponent<portal>().spawnPoint.transform.position;
            }
        }else if (Physics.Raycast(transform.position, transform.forward * direction, out hitMove, 1))
        {
            var endPosition = transform.position + (transform.forward * direction);
            transform.DOMove(endPosition, 1);
            transform.position += transform.up;
        }else if (!Physics.Raycast(transform.position + transform.forward * direction, Vector3.down, out hitEmpty, 1)){
            Debug.Log("is falling!");
            _animator?.SetBool(IS_FALLING, true);
            var endPosition = transform.position + (transform.forward * direction);
            transform.DOMove(endPosition, 1);
        }
        else{
            var endPosition = transform.position + (transform.forward * direction);
            transform.DOMove(endPosition, 1);
        }
    }

}

