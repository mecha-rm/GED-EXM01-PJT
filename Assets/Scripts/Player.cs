using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rigidBody;

    private Vector3 forceVec = new Vector3(5.0F, 5.0F, 10.0F);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
