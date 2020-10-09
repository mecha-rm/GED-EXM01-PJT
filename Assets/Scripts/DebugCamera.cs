using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCamera : MonoBehaviour
{
    // saves the starting position
    private Vector3 origPos;

    private Quaternion origRot;

    // movement speed
    public Vector3 movementSpeed = new Vector3(240.0F, 260.0F, 240.0F);

    // rotation speed
    public Vector3 rotationSpeed = new Vector3(230.0F, 230.0F, 230.0F);

    // Start is called before the first frame update
    void Start()
    {
        origPos = transform.position;
        origRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 translation = new Vector3();
        Vector3 rotation = new Vector3();

        // TRANSLATION
        // forward movement and backward movement
        if (Input.GetKey(KeyCode.W))
        {
            translation.z += movementSpeed.z * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            translation.z += -movementSpeed.z * Time.deltaTime;
        }

        // leftward and rightward movement
        if (Input.GetKey(KeyCode.A))
        {
            translation.x += -movementSpeed.x * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            translation.x += movementSpeed.x * Time.deltaTime;
        }

        // upward movement and downward movement
        if (Input.GetKey(KeyCode.Q))
        {
            translation.y += movementSpeed.y * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            translation.y += -movementSpeed.y * Time.deltaTime;
        }

        // translate camera
        transform.Translate(translation);

        // ROTATION
        // rotate left and right (y-axis rotation)
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotation.y += -rotationSpeed.y * Time.deltaTime;

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rotation.y += rotationSpeed.y * Time.deltaTime;
        }

        // rotate upward or downward (x-axis rotation)
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rotation.x += -rotationSpeed.x * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rotation.x += rotationSpeed.x * Time.deltaTime;
        }
        // rotate vision (z-axis rotation)
        if (Input.GetKey(KeyCode.PageUp))
        {
            rotation.z += -rotationSpeed.z * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.PageDown))
        {
            rotation.z += rotationSpeed.z * Time.deltaTime;
        }

        // rotate camera
        transform.Rotate(rotation);

        // reset position
        if(Input.GetKeyDown(KeyCode.P))
        {
            transform.position = origPos;
        }

        // reset 
        if(Input.GetKeyDown(KeyCode.R))
        {
            transform.rotation = origRot;
        }
    }
}
