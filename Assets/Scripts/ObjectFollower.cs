using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectFollower : MonoBehaviour
{
    public GameObject followee; // object being followed
    public Vector3 distance = new Vector3(0, 3, 10); // distance from leader

    // TODO: maybe have the camera lag behind?
    private Quaternion followeeRot; // gets the rotation of the followee.


    // Start is called before the first frame update
    void Start()
    {
        followeeRot = followee.transform.rotation;

    }

    // rotates around a vector. If an invalid number is passed, no rotation happens.
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
        temp = Quaternion.AngleAxis(followee.transform.rotation.eulerAngles.y, Vector3.up) * distance;

        // rotating up and down
        temp = Quaternion.AngleAxis(followee.transform.rotation.eulerAngles.x, Vector3.right) * temp;

        // sets the camera to its new position, and has it look at the entity.
        transform.position = followee.transform.position + temp;



        transform.LookAt(followee.transform.position);

    }
}
