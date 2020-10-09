using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    // TODO: add nodes to lerp between instead of just two points

    // start position and end position
    public Vector3 startPosition;
    public Vector3 endPosition;

    // tells the program what axes to use.
    public bool useX = true, useY = true, useZ = true;

    // time
    private float t = 0.0F;

    // loops back and fourth instead of starting over
    bool loop = true;

    // incrementer
    public float movementFactor = 1.0F;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // adds to 't' value
        t += movementFactor * Time.deltaTime;
        t = Mathf.Clamp(t, 0.0F, 1.0F);

        // lerps between values
        Vector3 newPos = Vector3.Lerp(startPosition, endPosition, t);

        // if an axis shouldn't be used, then that value is restored.
        if(!useX)
            newPos.x = transform.position.x;
        if (!useY)
            newPos.y = transform.position.y;
        if (!useZ)
            newPos.z = transform.position.z;

        // changes the position
        transform.position = newPos;

        // bringing t back to 0
        if(t >= 1.0F)
        {
            if(loop) // if the platform should loop.
            {
                Vector3 temp = startPosition;
                startPosition = endPosition;
                endPosition = temp;
            }

            t = 0.0F;
        }
    }
}
