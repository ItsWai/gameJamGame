using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private int sceneBuildIndex;

    public void PlayGame()
    {
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    



    
    
}
