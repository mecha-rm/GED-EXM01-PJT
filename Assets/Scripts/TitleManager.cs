using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // changes the scene
    public void SwitchScene(string scene)
    {
        SceneManager.LoadScene(scene);
        
    }

    // changes the scene
    public void SwitchScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void DontDestroyOnLoad()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
