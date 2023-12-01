using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;

    [SerializeField] private int sceneBuildIndex;
    [SerializeField] private int sceneBuildIndex1;
    [SerializeField] private int sceneBuildIndex2;
    [SerializeField] private int sceneBuildIndex3;
    [SerializeField] private int sceneBuildIndex4;
    [SerializeField] private int sceneBuildIndex5;
    [SerializeField] private int sceneBuildIndex6;
    [SerializeField] private int sceneBuildIndex7;
    [SerializeField] private int sceneBuildIndexMain;



    private void Update()
    {
        
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel());
    }
    public void LoadNextLevel1()
    {
        StartCoroutine(LoadLevel1());
    }
    public void LoadNextLevel2()
    {
        StartCoroutine(LoadLevel2());
    }
    public void LoadNextLevel3()
    {
        StartCoroutine(LoadLevel3());
    }
    public void LoadNextLevel4()
    {
        StartCoroutine(LoadLevel4());
    }
    public void LoadNextLevel5()
    {
        StartCoroutine(LoadLevel5());
    }
    public void LoadNextLevel6()
    {
        StartCoroutine(LoadLevel6());
    }
    public void LoadNextLevel7()
    {
        StartCoroutine(LoadLevel7());
    }
    public void LoadNextLevelMain()
    {
        StartCoroutine(LoadLevelMain());
    }


    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }
    IEnumerator LoadLevel1()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(sceneBuildIndex1, LoadSceneMode.Single);
    }
    
    IEnumerator LoadLevel2()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(sceneBuildIndex2, LoadSceneMode.Single);
    }
    IEnumerator LoadLevel3()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(sceneBuildIndex3, LoadSceneMode.Single);
    }
    IEnumerator LoadLevel4()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(sceneBuildIndex4, LoadSceneMode.Single);
    }
    IEnumerator LoadLevel5()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(sceneBuildIndex5, LoadSceneMode.Single);
    }
    IEnumerator LoadLevel6()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(sceneBuildIndex6, LoadSceneMode.Single);
    }
    IEnumerator LoadLevel7()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(sceneBuildIndex7, LoadSceneMode.Single);
    }

    IEnumerator LoadLevelMain()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(sceneBuildIndexMain, LoadSceneMode.Single);
    }
}
