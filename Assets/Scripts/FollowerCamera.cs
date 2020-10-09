using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// this should be renamed to be more accurate.
public class FollowerCamera : MonoBehaviour
{
    public GameObject followee; // object being followed
    public Vector3 distance = new Vector3(0, 3, 10); // distance from leader

    // TODO: maybe have the camera lag behind?
    private Quaternion followeeRot; // gets the rotation of the followee.

    // saves the rotation applied to the camera
    private Vector3 camRot = new Vector3(0.0F, 0.0F, 0.0F);
    private Vector3 rotSpeed = new Vector3(100.0F, 100.0F, 0.0F);
    private Vector2 xRotLimit = new Vector2(-50.0F, 50.0F);


    // Start is called before the first frame update
    void Start()
    {
        followeeRot = followee.transform.rotation;

    }

    // rotates around a vector. If an invalid number is passed, no rotation happens. Unused.
    // 0 = x-axis, 1 = y-axis, 2 = z-axis
    private Vector3 RotateVector(Vector3 vec, float angle, int axis)
    {
        // Vector3.RotateTowards(;
        Matrix4x4 rMatrix = new Matrix4x4();

        // rotation matrix - x-axis
        // [ 1, 0, 0 ]
        // [ 0, cos a, -sin a]
        // [ 0, sin a, cos a]

        // rotation matrix - y-axis
        // [ cos  a, 0, sin a]
        // [ 0, 1, 0]
        // [ -sin a, 0, cos a]

        // rotation matrix - z-axis
        // [ cos a, -sin a, 0]
        // [ sin a, cos a, 0]
        // [ 0, 0, 1]

        switch (axis)
        {
            case 0: // x-axis
                rMatrix.SetRow(0, new Vector4(1.0F, 0.0F, 0.0F, 0.0F));
                rMatrix.SetRow(1, new Vector4(0.0F, Mathf.Cos(angle), -Mathf.Sin(angle), 0.0F));
                rMatrix.SetRow(2, new Vector4(0.0F, Mathf.Sin(angle), Mathf.Cos(angle), 0.0F));
                rMatrix.SetRow(3, new Vector4(0.0F, 0.0F, 0.0F, 1.0F));
                break;

            case 1: // y-axis
                rMatrix.SetRow(0, new Vector4(Mathf.Cos(angle), 0.0F, Mathf.Sin(angle), 0.0F));
                rMatrix.SetRow(1, new Vector4(0.0F, 1.0F, 0.0F, 0.0F));
                rMatrix.SetRow(2, new Vector4(-Mathf.Sin(angle), 0.0F, Mathf.Cos(angle), 0.0F));
                rMatrix.SetRow(3, new Vector4(0.0F, 0.0F, 0.0F, 1.0F));
                break;

            case 2: // z-axis
                rMatrix.SetRow(0, new Vector4(Mathf.Cos(angle), -Mathf.Sin(angle), 0.0F, 0.0F));
                rMatrix.SetRow(1, new Vector4(Mathf.Sin(angle), Mathf.Cos(angle), 0.0F, 0.0F));
                rMatrix.SetRow(2, new Vector4(0.0F, 0.0F, 1.0F, 0.0F));
                rMatrix.SetRow(3, new Vector4(0.0F, 0.0F, 0.0F, 1.0F));
                break;

            default: // no match
                return vec;

        }

        return rMatrix.MultiplyVector(vec);
    }

    // Update is called once per frame
    void Update()
    {
        // original
        // transform.position = followee.transform.position + distance;
       
        // rotates the camera around the camera
        // rotates the vector to reposition the camera.
        Vector3 temp = distance;

        // rotating left and right
        // temp = Quaternion.AngleAxis(followee.transform.rotation.eulerAngles.y, Vector3.up) * distance;
        // 
        // // rotating up and down
        // temp = Quaternion.AngleAxis(followee.transform.rotation.eulerAngles.x, Vector3.right) * temp;

        // moving camera
        {
            // rotating around x-axis
            if (Input.GetKey(KeyCode.UpArrow)) // look up
            {
                camRot.x += -rotSpeed.x * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.DownArrow)) // look down
            {
                camRot.x += rotSpeed.x * Time.deltaTime;
            }

            // clamps between values
            camRot.x = Mathf.Clamp(camRot.x, xRotLimit.x, xRotLimit.y);


            // rotating around y-axis
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) // look left
            {
                camRot.y += -rotSpeed.y * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) // look right
            {
                camRot.y += rotSpeed.y * Time.deltaTime;
            }

            Vector3 origPos = transform.position; // saves original position
            Quaternion origRot = transform.rotation; // save soriginal rotation

            // places the camera relative to world origin, then rotates it.
            transform.position = distance; // sets position to distance
            transform.rotation = new Quaternion(0, 0, 0, 1); // resets rotation to (0, 0, 0)

            transform.RotateAround(new Vector3(0, 0, 0), Vector3.right, camRot.x); // x-axis rotation
            transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, camRot.y); // y-axis rotation

            // gets the transformation position
            temp = transform.position;

            // returns values back to originals
            transform.position = origPos;
            transform.rotation = origRot;

            // recenter's camera behind player, resetting all rotations if both are triggered.
            // resets y-axis rotation (look left and right)
            if(Input.GetKey(KeyCode.PageUp) || Input.GetKey(KeyCode.R))
            {
                temp = distance;
                camRot.y = 0.0F;
            }
            // resets x-axis rotation (look up and down)
            if(Input.GetKey(KeyCode.PageDown) || Input.GetKey(KeyCode.R))
            {
                camRot.x = 0.0F;
            }
            // this isn't used, but it might as well be reset too.
            if(Input.GetKey(KeyCode.R))
            {
                camRot.z = 0.0F;
            }
        }

        // sets the camera to its new position, and has it look at the entity.
        transform.position = followee.transform.position + temp;
        transform.LookAt(followee.transform.position);

    }
}
