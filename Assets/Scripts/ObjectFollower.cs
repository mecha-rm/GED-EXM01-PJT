using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    public GameObject followee; // object being followed
    public Vector3 distance = new Vector3(0, 3, 10); // distance from leader

    // TODO: maybe have the camera lag behind?

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = followee.transform.position + distance;
    }
}
