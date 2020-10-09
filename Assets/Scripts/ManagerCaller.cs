using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCaller : MonoBehaviour
{

    public GameplayManager gpManager;

    // set to number to call function
    /*
     * 1 = Start Point 
     * 2 = End Point
     * 3 = Checkpoint
     */
    public int funcCall = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // called when the object is collded with.
    private void OnTriggerEnter(Collider other)
    {
        // function call has been triggered.
        bool triggered = false;

        // goes through each function call
        switch(funcCall)
        {
            case 1: // start point
                gpManager.StartpointTrigger();
                triggered = true;
                break;
            case 2: // end point
                gpManager.EndpointTrigger();
                triggered = true;
                break;
            case 3: // checkpoint
                gpManager.CheckpointTrigger(transform.position);
                triggered = true;
                break;
        }

        // deactivates the object since it's no longer in use.
        if(triggered)
            gameObject.SetActive(false);

        // if(activated == true)
        //     active
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
