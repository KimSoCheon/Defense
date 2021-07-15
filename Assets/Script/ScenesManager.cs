using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void GameStart()
    {
        SceneManager.LoadScene(1);
        //1¹ø¾À ºÒ·¯¿È
    }

    public void GameExit()
    {
        Application.Quit();
        //°ÔÀÓÁ¾·á
    }
}
