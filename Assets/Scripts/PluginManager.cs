using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PluginManager : MonoBehaviour
{
    const string DLL_NAME = "GED - EXM01";

    // Functions from DLL
    [DllImport(DLL_NAME)]
    private static extern void ResetLogger();

    [DllImport(DLL_NAME)]
    private static extern void SaveCheckpointTime();

    [DllImport(DLL_NAME)]
    private static extern float GetTotalTime();

    [DllImport(DLL_NAME)]
    private static extern float GetTimeSinceLastCheckpoint();

    [DllImport(DLL_NAME)]
    private static extern float GetCheckpointTime(int index);

    [DllImport(DLL_NAME)]
    private static extern int GetNumberOfCheckpoints();

    [DllImport(DLL_NAME)]
    private static extern void UpdateLogger(float deltaTime);

    // Start is called before the first frame update
    void Start()
    {
        ResetLogger(); // start the timer
    }

    // resets the logger
    public void ResetCheckpointTimeSystem()
    {
        ResetLogger();
    }

    // called when a checkpoint is reached
    public void CheckpointReached()
    {
        SaveCheckpointTime();
    }

    // gets the total time
    public float GetTotalPlayTime()
    {
        return GetTotalTime();
    }

    // returns the time since the last checkpoint
    public float GetElapsedTimeSinceLastCheckpoint()
    {
        return GetTimeSinceLastCheckpoint();
    }

    // returns the time it took to reach a provided checkpoint
    public float GetCheckpointActivationTime(int index)
    {
        return GetCheckpointTime(index);
    }

    // returns the amount of checkpoints
    public int GetCheckpointAmount()
    {
        return GetNumberOfCheckpoints();
    }
    

    // Update is called once per frame
    void Update()
    {
        UpdateLogger(Time.deltaTime);
    }
}
