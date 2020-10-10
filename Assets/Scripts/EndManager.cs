using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class EndManager : MonoBehaviour
{
    public Text endText;

    // loads the DLL
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
        // the end text exists
        if (endText != null)
        {
            int CP_TOTAL = GetNumberOfCheckpoints();

            // adds each score
            for (int i = 0; i < CP_TOTAL; i++)
            {
                endText.text += "\nCheckpoint " + i + " - " + GetCheckpointTime(i);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
