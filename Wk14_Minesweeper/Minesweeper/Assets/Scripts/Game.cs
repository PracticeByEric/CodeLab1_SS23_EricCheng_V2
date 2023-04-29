using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    // size of the actual gameboard
    [SerializeField] int width = 16;
    [SerializeField] int height = 16;

    private GameBoard _gameBoard;
    private Cell[,] state;
    
    private void Awake()
    {
        // to call the draw function
        _gameBoard = GetComponentInChildren<GameBoard>();
    }

    private void Start()
    {
        // restart the game or start the game
        NewGame();
    }

    private void NewGame()
    {
        state = new Cell[width, height];
        GenerateCells();
        
        // center the board by adjusting camera
        // move camera half width and half height away, keep z as default
        Camera.main.transform.position = new Vector3(width/2, height/2, -10f);
        
        //update board
        _gameBoard.Draw(state);
    }

    // Generate all elements by layers
    // LAYER 1: Generate cell on each cell on the gameboard
    private void GenerateCells()
    {
        for (int x = 0; x < width; x++) 
        {
            for (int y = 0; y < height; y++)
            {
                // fill in info for each cell in the board
                Cell cell = new Cell();
                cell.position = new Vector3Int(x, y, 0);
                cell.type = Cell.Type.Empty;
                // assign cell into array
                state[x, y] = cell;
            }
        }
    }
}
