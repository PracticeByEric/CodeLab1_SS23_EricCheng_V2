using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSceneChanger : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        LevelManager.Instance.LoadScene(sceneName);
    }
}
