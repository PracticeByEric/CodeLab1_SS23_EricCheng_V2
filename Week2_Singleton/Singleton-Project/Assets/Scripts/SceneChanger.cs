using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        LoadNewScene();
        
        
    }

    void LoadNewScene()
    {
        SceneManager.LoadScene("Scene1");
        
        PropellerRotation.Instance.rAngle += 50;
        
        PlayerControl.Instance.transform.position = new Vector3(-0.5f, 12f, 3.9f);
        PlayerControl.Instance._rb.velocity = Vector3.zero;
        PlayerControl.Instance._rb.useGravity = false;
    }
}
