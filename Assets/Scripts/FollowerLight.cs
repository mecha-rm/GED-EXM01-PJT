using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class FollowerLight : MonoBehaviour
{
    public GameObject followee; // object being followed
    // public Vector3 distance = new Vector3(0, 0, 0); // distance from leader
    private Vector3 distance;

    // Start is called before the first frame update
    void Start()
    {
        distance = followee.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = followee.transform.position - distance;
    }
}
