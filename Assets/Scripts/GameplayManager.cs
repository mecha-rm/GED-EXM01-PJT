using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    public PluginManager pManager;
    public DeathPlane dpManager;

    // scene that comes after current scene
    public string nextScene;

    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // start point has been triggered
    public void StartpointTrigger(Vector3 startPos)
    {
        dpManager.respawnPosition = startPos;
    }

    // checkpoint has been triggered
    public void CheckpointTrigger(Vector3 cptPos)
    {
        pManager.CheckpointReached(); // checkpoint has been reached
        dpManager.respawnPosition = cptPos; // player now respawns at checkpoint
    }

    // end point has been triggered
    public void EndpointTrigger()
    {
        pManager.CheckpointReached();

        // load next maze (if possible)
        // else end game

        // loads the ending scene
        SceneManager.LoadScene(nextScene);
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = "Time Since Last Checkpoint\n" + pManager.GetElapsedTimeSinceLastCheckpoint();
        
    }
}
