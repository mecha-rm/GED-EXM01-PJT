using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    // entity the death plane is attached to.
    public GameObject entity;

    // the distance on the y-axis between the death plane.
    public float yDist = 50.0F;

    // the position on the y-axis that the death plane cannot go beyond. This allows the player to collide with it.
    public float yPosLimit = -70.0F;

    // the respawn position when the entity hits the death pane.
    public Vector3 respawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        // by default, it's the original game object position
        respawnPosition = entity.transform.position;
    }

    // when collision happens with the player.
    private void OnTriggerEnter(Collider other)
    {
        // if the right entity has collided.
        // if(entity.GetComponent<Collider>() == other)
        {
            // resets entity back to original position
            entity.transform.position = respawnPosition;

            Vector3 text = entity.GetComponent<Rigidbody>().velocity;
            // entity.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            // entity.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    // private void OnTriggerExit(Collider other)
    // {
    //     
    // }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = entity.transform.position;

        // if the plane has moved too far below the player.
        if (newPos.y - yDist < yPosLimit)
            newPos.y = yPosLimit;
        else
            newPos.y -= yDist;

        transform.position = newPos;
    }
}
