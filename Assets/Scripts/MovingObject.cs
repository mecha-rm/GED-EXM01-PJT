using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    // TODO: add nodes to lerp between instead of just two points

    // start position and end position
    public Vector3 startPosition;
    public Vector3 endPosition;

    // time
    private float t = 0.0F;

    // loops back and fourth instead of starting over
    bool loop = true;

    // incrementer
    public float incrementer = 0.01F;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // adds to 't' value
        t += incrementer * Time.deltaTime;
        t = Mathf.Clamp(t, 0.0F, 1.0F);

        // lerps between values
        transform.position = Vector3.Lerp(startPosition, endPosition, t);

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
