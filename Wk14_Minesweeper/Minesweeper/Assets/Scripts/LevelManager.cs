using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private Image progressBar;
    [SerializeField] private GameObject loaderCanvas;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public async void LoadScene(string sceneName)
    {
        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;
        
        //showing the loader
        loaderCanvas.SetActive(true);

        do
        {
            progressBar.fillAmount = scene.progress;
        } while (scene.progress < 0.9f);
        
        scene.allowSceneActivation = true;
        loaderCanvas.SetActive(false);

    }
}
