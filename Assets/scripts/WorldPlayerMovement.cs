using UnityEngine;

public class WorldPlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;
    }

    void FixedUpdate()
    {
        var _horizontalInput = Input.GetAxisRaw("Horizontal");
        var _verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(_horizontalInput, 0, _verticalInput);
        _rigidbody.AddForce(movement * speed);

        var animator = GetComponentInChildren<Animator>();

        if (animator is not null)
        {
            animator?.SetBool("isRunning", _rigidbody.velocity.magnitude > 1.5);
        }
    }
}
