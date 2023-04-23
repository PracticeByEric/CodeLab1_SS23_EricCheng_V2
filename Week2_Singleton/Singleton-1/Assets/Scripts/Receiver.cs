using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Receiver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // The Singleton instance is passed to scene1
        // Receiver able to call the function native to instance object
        Singleton.instance.DisplayText();
        
        // print out coin collected amount in different scene
        Debug.Log("Coin collected:" + Singleton.instance.coinCollected);
        
        // switch back to the old scene
        Invoke("LoadOldScene", 5f);
    }

    void LoadOldScene()
    {
        SceneManager.LoadScene("Scene0");
    }
}
