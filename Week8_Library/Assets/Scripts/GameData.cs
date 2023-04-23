using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameData")]
public class GameData : ScriptableObject
{
    public int score = 0;
    public float gameTime = 0.0f;
    public bool isGameOver = false;

    public void Reset()
    {
        score = 0;
        gameTime = 0.0f;
        isGameOver = false;
    }
}

