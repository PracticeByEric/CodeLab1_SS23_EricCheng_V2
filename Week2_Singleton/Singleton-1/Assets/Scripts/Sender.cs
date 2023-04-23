using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sender : MonoBehaviour
{
    // Start is called before the first frame update

    /*
    private Singleton sin;
    private Singleton sin_2;*/
    void Start()
    {
        // get component from another game object
        /*sin = GameObject.Find("Singleton").GetComponent<Singleton>();
        sin_2 = GameObject.Find("Singleton").GetComponent<Singleton>();
        
        sin.DisplayText();
        sin_2.DisplayText();*/
        
        // create static instance to replace code above
        // easily access singleton object
        // Singleton.instance.DisplayText();
        
        // Invoke LoadNewScene function after 3 seconds

        // set coin collected amount to be 2
        Singleton.instance.coinCollected = 2;
        
        Invoke("LoadNewScene", 3f);
    }

    void LoadNewScene()
    {
        // load anther scene
        // scene need to be added to the builder
        SceneManager.LoadScene("Scene1");
    }

}
