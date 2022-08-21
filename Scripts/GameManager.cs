using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        //Singleton method
        if (instance == null)
        {
            //First run, set the instance
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else if (instance != this)
        {
            //Instance is not the same as the one we have, destroy old one, and reset to newest one
            Destroy(instance.gameObject);
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    public void StartGame()
    {
        print("StartGame");
        StartCoroutine(GameCoroutine());
    }
    private IEnumerator GameCoroutine()
    {
        yield return StartCoroutine(LoadScene());
        LevelManager lm = FindObjectOfType<LevelManager>();
    }

    private IEnumerator LoadScene()
    {
        SceneManager.LoadScene("SampleScene");
        yield return null;
    }
}
