using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class player : MonoBehaviour
{
    const string IS_FALLING = "isFalling";
    const string IS_MOVING = "isMoving";

    public GameObject spawnPoint;
    private Animator _animator;
    private bool isMoving = false;

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
        if (isMoving)
            return;

        if (GetComponent<Rigidbody>().velocity.y > -0.5)
        {
            _animator.SetBool(IS_FALLING, false);
        }

        _animator?.SetBool(IS_MOVING, false);
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
        }else if (Physics.Raycast(transform.position, transform.forward * direction, out hitMove, 1))
        {
            toggleIsMoving();
            _animator.SetBool(IS_MOVING, true);
            var endPosition = transform.position + (transform.forward * direction) + transform.up;
            transform.DOMove(endPosition, .3f).OnComplete(toggleIsMoving);
            FindObjectOfType<AudioManager>().Play("jump");
        }else if (!Physics.Raycast(transform.position + transform.forward * direction, Vector3.down, out hitEmpty, 1)){
            Debug.Log("is falling!");
            FindObjectOfType<AudioManager>().Play("fall");
            toggleIsMoving();
            _animator.SetBool(IS_FALLING, true);
            var endPosition = transform.position + (transform.forward * direction);
            transform.DOMove(endPosition, .3f).OnComplete(toggleIsMoving);
        }
        else{
            _animator.SetBool(IS_MOVING, true);
            toggleIsMoving();
            var endPosition = transform.position + (transform.forward * direction);
            transform.DOMove(endPosition, .3f).OnComplete(toggleIsMoving);
        }
    }

    void toggleIsMoving()
    {
        isMoving = !isMoving;
    }

}

