using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameData gameData;

    void Start()
    {
        gameData.Reset();
    }

    void Update()
    {
        if (!gameData.isGameOver)
        {
            // Game logic here
        }
    }
}
