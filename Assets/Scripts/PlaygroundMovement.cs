using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlaygroundMovement : MonoBehaviour
{


    public float horizontalInput ;
    public float verticalInput ;

    public float horizontalRotation;
    public float verticalRotation;

    private Rigidbody rb;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        InputPlayGround();
    }


    void InputPlayGround() {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (horizontalInput == 0) {
            horizontalRotation = Mathf.LerpAngle(horizontalRotation, 0, 0.05f);
        } else {
            horizontalRotation = Mathf.LerpAngle(rb.rotation.eulerAngles.z, -horizontalInput*10, 0.05f);
        }
        if (verticalInput == 0) {
            verticalRotation = Mathf.LerpAngle(verticalRotation, 0, 0.05f);
        } else {
            verticalRotation = Mathf.LerpAngle(rb.rotation.eulerAngles.x, verticalInput*10, 0.05f);
        }

        Quaternion deltaRotation = Quaternion.Euler(verticalRotation, 0, horizontalRotation);

        rb.MoveRotation(deltaRotation);

    }
}
