using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // the player camera (used for direction)
    public GameObject playerCamera;

    public Rigidbody rigidBody;

    // movement force
    public float moveForce = 1000.0F;
    public float jumpForce = 5000.0F;

    // rotation speed
    public float rotSpeed = 90.0F;

    // provides force in a given direction (if enabled)
    private Vector3 forceVec = new Vector3(20.0F, 20.0F, 20.0F);

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
        else
        {
            // this was taken from prior in-class work from Intermediate Game Design
            // float turnSpeed = 115.0F;
            // Horizontal zxis -> left and right keys (or A and D)
            // float horizontal = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
            // transform.Rotate(0, horizontal, 0);

            // left and right - uncommented
            // float theta = Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
            // transform.Rotate(0, theta, 0);

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

            // uncommented
            // float moveFactor = Input.GetAxis("Vertical") * moveForce * Time.deltaTime;

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

            // FIX this later - uncommented
            // transform.Translate(0, 0, moveFactor);
            // rigidBody.AddForce(Vector3.forward * moveFactor);

            //Vertical Axis -> up and down keys (or W and S)
            // float movementSpeed = 115.0F;
            // float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
            // transform.Translate(0, 0, vertical);

            // camera rotation
            // {
            //     // original position and rotation
            //     Vector3 origPos = transform.position;
            //     Quaternion origRot = transform.rotation;
            // 
            //     // resets object to default position and rotation
            //     transform.position = new Vector3();
            //     transform.rotation = new Quaternion(0, 0, 0, 1);
            // 
            //     Vector3 camRot = playerCamera.transform.rotation.eulerAngles;
            //     Vector3 temp = transform.forward;
            // 
            //     transform.RotateAround(new Vector3(0, 0, 0), Vector3.right, camRot.x); 
            // 
            // }
            // 
            // // rotate in opposite y-direction
            // tVec.y += 180.0F;

            // camera rotation
            Vector3 direcVec = new Vector3();

            // getting the forward direction vector
            {
                Vector3 origPos = transform.position;
                Quaternion origRot = transform.rotation;

                // recieves the camera rotation
                Vector3 camRot = playerCamera.transform.rotation.eulerAngles;
                camRot.y += 180.0F; // reverse direction

                // the camera's position relative to the player.
                // this has already been offset by the camera's rotation.
                Vector3 camOffsetPos = transform.position - playerCamera.transform.position;
                Vector3 camOffsetPosInv = camOffsetPos * -1; // reverse direction

                // gets a normalized version of the vector
                direcVec = camOffsetPosInv.normalized;

                // if there is velocity
                // if(rigidBody.velocity != new Vector3(0, 0, 0))
                // {
                //     // gets the angle between the two vectors
                //     float angle = Vector3.Angle(rigidBody.velocity, camOffsetPosInv);
                //     Vector3 rVec = Vector3.RotateTowards(rigidBody.velocity, camOffsetPosInv, 6.0F, 100.0F);
                //     rVec.y = rigidBody.velocity.y;
                // 
                //     // saves the new velocity
                //     rigidBody.velocity = rVec;
                // }

                // Movement
                // forward and backward movement
                if (Input.GetKey(KeyCode.W))
                {
                    rigidBody.AddForce(new Vector3(direcVec.x, 0.0F, direcVec.z) * -moveForce * Time.deltaTime);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    rigidBody.AddForce(new Vector3(direcVec.x, 0.0F, direcVec.z) * moveForce * Time.deltaTime);
                }

                // jumping
                if (Input.GetKey(KeyCode.Space) && rigidBody.velocity.y == 0.0F)
                    rigidBody.AddForce(new Vector3(0.0F, jumpForce * Time.deltaTime, 0.0F));

                // cancels out all momentum.
                if (Input.GetKey(KeyCode.P))
                    rigidBody.velocity = new Vector3(0.0F, rigidBody.velocity.y, 0.0F);
            }



            // leftward and rightward movement
            // if (Input.GetKey(KeyCode.A))
            // {
            //     rigidBody.AddForce(Vector3.left * forceVec.x);
            // }
            // if (Input.GetKey(KeyCode.D))
            // {
            //     rigidBody.AddForce(Vector3.right * forceVec.x);
            // }
        }

    }
}
