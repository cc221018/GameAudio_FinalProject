using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


internal enum MovementType {
    TransformBased,
    PhysicsBased
}


public class Movement : MonoBehaviour
{
    [SerializeField]
    private float _velocity = 1;

    [SerializeField]
    private float _jumpForce = 5;

    [SerializeField]
    private ForceMode forceMode;

    [SerializeField]
    private MovementType movementType;

    private Vector3 movementDirection3d;
    private Rigidbody _rigidbody;
    private bool isGrounded = true;

    private int walkingId;
    private int movementKeysPressed;

    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
       /* if (Input.GetKey(KeyCode.W))
            gameObject.transform.position += new Vector3(0, 0, -1f) * _velocity;*/
        PerformMovement();
    }

    void PerformMovement() {

        if (movementType == MovementType.TransformBased) {
            gameObject.transform.position += movementDirection3d * _velocity;
        }
        else if (movementType == MovementType.PhysicsBased) {
            _rigidbody.AddForce(movementDirection3d, forceMode);
            AkSoundEngine.SetRTPCValue("speed", _rigidbody.velocity.magnitude);
        }        
    }

    void OnMovement(InputValue inputValue)
    {
        Vector2 movementDirection = inputValue.Get<Vector2>();
        movementDirection3d = new Vector3(movementDirection.x, 0, movementDirection.y);

    }
    

    void OnJump(InputValue inputValue) {
        if (inputValue.isPressed && isGrounded) {       // ".isPressed" = property of Unity's input system -> InputValue property
            _rigidbody.AddForce(Vector3.up * _jumpForce, forceMode);
            isGrounded = false;
            // AkSoundEngine.PostEvent("Play_jump", gameObject);
        }
    }

    void OnCollisionEnter(Collision collision) {        // Unity-specific callback -> triggered when a Rigidbody / Collider component collides with another Collider
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }

        if (collision.gameObject.name.Contains("Lawn")) {
            AkSoundEngine.SetState("steps", "grass");
        }

        if (collision.gameObject.name.Contains("Street")) {
            AkSoundEngine.SetState("steps", "street");
        }

        if (collision.gameObject.name.Contains("Wood")) {
            AkSoundEngine.SetSwitch("indoor_ground", "wood", this.gameObject);
        }

        if (collision.gameObject.name.Contains("Stone")) {
            AkSoundEngine.SetSwitch("indoor_ground", "stone", this.gameObject);
        }
    }
    

    private void OnTriggerEnter (Collider other) {
        if (other.gameObject.CompareTag("Coin")) {
            AkSoundEngine.PostEvent("Play_coin", other.gameObject);
        }

        if (other.gameObject.name.Contains("Witch")) {
            AkSoundEngine.PostEvent("Play_laughing_witch", other.gameObject);
        }

        if (other.gameObject.name.Contains("Doorbell")) {
            AkSoundEngine.PostEvent("Play_doorbell", other.gameObject);
        }

        if (other.gameObject.name.Contains("Knock")) {
            AkSoundEngine.PostEvent("Play_door_knock", other.gameObject);
        }

        // if (other.gameObject.name.Contains("Scene")) {
        //     AkSoundEngine.StopPlayingID((uid))
        // }
    }

}
