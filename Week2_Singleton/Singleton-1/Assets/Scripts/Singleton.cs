using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// a class is a blur print of creating object
// This Singleton class can also be called "GameManager"
public class Singleton : MonoBehaviour
{
    // create an object from Singleton class within the Singleton class
    // allocate space on memory for Singleton instance
    public static Singleton instance;
    // Start is called before the first frame update
    
    //Singleton characteristic example, coin collected
    [HideInInspector] public int coinCollected;

    private void Awake()
    {
        // create a static object instance when script loaded
        MakeSingleton();
    }

    void Start()
    {
       // DisplayText();
    }

    // create singleton
    void MakeSingleton()
    {
        // to avoid duplicate object
        if (instance != null)
        {
            // if there is two game object hold same script, destroy the later one
            Destroy(gameObject);
        }
        // if no Singleton instance created
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void DisplayText()
    {
        print("Excuted from function");
    }
}
