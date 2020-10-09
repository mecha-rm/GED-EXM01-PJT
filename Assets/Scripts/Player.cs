using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rigidBody;

    // movement force
    public float moveForce = 60.0F;

    // rotation speed
    public float rotSpeed = 90.0F;

    // provides force in a given direction (if enabled)
    private Vector3 forceVec = new Vector3(5.0F, 5.0F, 10.0F);

    // rotates at a given speed
    private Vector3 rotationSpeed = new Vector3(15.0F, 15.0F, 15.0F);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if 'true', the object can apply force in all directions
        const bool MULTI_DIREC = false;

        
        if(MULTI_DIREC)
        {
            // Movement
            // forward and backward movement
            if (Input.GetKey(KeyCode.W))
            {
                rigidBody.AddForce(Vector3.forward * forceVec.z);

            }
            if (Input.GetKey(KeyCode.S))
            {
                rigidBody.AddForce(Vector3.back * forceVec.z);
            }

            // leftward and rightward movement
            if (Input.GetKey(KeyCode.A))
            {
                rigidBody.AddForce(Vector3.left * forceVec.x);
            }
            if (Input.GetKey(KeyCode.D))
            {
                rigidBody.AddForce(Vector3.right * forceVec.x);
            }

            // upward and downward movement
            if (Input.GetKey(KeyCode.Q))
            {
                rigidBody.AddForce(Vector3.up * forceVec.y);
            }
            if (Input.GetKey(KeyCode.E))
            {
                rigidBody.AddForce(Vector3.down * forceVec.y);
            }

            // Rotation
            Vector3 rot = new Vector3();

            // rotate left and right (y-axis rotation)
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rot.y += rotationSpeed.y * Time.deltaTime;

            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                rot.y += -rotationSpeed.y * Time.deltaTime;
            }

            // rotate upward or downward (x-axis rotation)
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rot.x += rotationSpeed.x * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                rot.x += -rotationSpeed.x * Time.deltaTime;
            }

            // unneeded
            // rotate vision (z-axis rotation)
            if (Input.GetKey(KeyCode.PageUp))
            {
                rot.z += rotationSpeed.z * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.PageDown))
            {
                rot.z += -rotationSpeed.z * Time.deltaTime;
            }

            transform.Rotate(rot);
        }


        {
            // this was taken from prior in-class work from Intermediate Game Design
            // float turnSpeed = 115.0F;
            // Horizontal zxis -> left and right keys (or A and D)
            // float horizontal = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
            // transform.Rotate(0, horizontal, 0);

            // left and right
            float theta = Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
            transform.Rotate(0, theta, 0);

            // up and down
            // if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
            // {
            //     theta = Input.GetAxis("Vertical") * -rotSpeed * Time.deltaTime;
            //     transform.Rotate(theta, 0, 0);
            // }
            // else
            // {
            //     // gets the amount of force being applied
            //     float moveFactor = Input.GetAxis("Vertical") * moveForce * Time.deltaTime;
            //     transform.Translate(0, 0, moveFactor);
            // }

            float moveFactor = Input.GetAxis("Vertical") * moveForce * Time.deltaTime;
            //rigidBody.AddForce(Vector3.up * forceVec.y);
            // if (Input.GetKey(KeyCode.W))
            // {
            //     // Vector3 f = Vector3.forward * moveFactor;
            //     // Vector3 rf = Quaternion.AngleAxis(transform.rotation.eulerAngles.y, Vector3.up) * f;
            //     // rigidBody.AddForce(rf);
            // 
            // 
            // }
            // else if (Input.GetKey(KeyCode.S))
            // {
            //     // Vector3 f = Vector3.back * moveFactor;
            //     // Vector3 rf = Quaternion.AngleAxis(transform.rotation.eulerAngles.y + 180.0F, Vector3.up) * f;
            //     // rigidBody.AddForce(rf);
            // }

            // FIX this later
            transform.Translate(0, 0, moveFactor);
            // rigidBody.AddForce(Vector3.forward * moveFactor);

            //Vertical Axis -> up and down keys (or W and S)
            // float movementSpeed = 115.0F;
            // float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
            // transform.Translate(0, 0, vertical);
        }

    }
}
