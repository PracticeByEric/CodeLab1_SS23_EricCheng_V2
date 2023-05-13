using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

// decide which tile to draw on the gameboard
public class GameBoard : MonoBehaviour
{
    public Tilemap tilemap { get; private set; }

    [SerializeField] private Tile tileUnknown;
    [SerializeField] private Tile tileEmpty;
    [SerializeField] private Tile tileMine;
    [SerializeField] private Tile tileExploded;
    [SerializeField] private Tile tileFlag;
    [SerializeField] private Tile tileNum1;
    [SerializeField] private Tile tileNum2;
    [SerializeField] private Tile tileNum3;
    [SerializeField] private Tile tileNum4;
    [SerializeField] private Tile tileNum5;
    [SerializeField] private Tile tileNum6;
    [SerializeField] private Tile tileNum7;
    [SerializeField] private Tile tileNum8;


    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
    }

    // draw the entire gameboard with cells
    // cell is 2d array for its location on x, y axis
    public void Draw(Cell[,] state)
    {
        // get w of the grid
        int width = state.GetLength(0);
        // get l of the grid
        int heigt = state.GetLength(1);
        
        // loop through each individual cell on the board
        for (int i = 0; i < width; i++) 
        {
            for (int j = 0; j < heigt; j++)
            {
                // set up coordinates location for the cell
                Cell cell = state[i, j];
                // render each cell with info in data structure set
                tilemap.SetTile(cell.position, GetTile(cell));
            }
        }
    }

    // determine what tile is behind
    private Tile GetTile(Cell cell)
    {
        if (cell.revealed)
        {
            return GetRevealedTile(cell);
        }
        else if(cell.flagged)
        {
            return tileFlag;
        }
        else
        {
            return tileUnknown;
        }
    }

    private Tile GetRevealedTile(Cell cell)
    {
        switch (cell.type)
        {
            case Cell.Type.Empty: return tileEmpty;
            case Cell.Type.Mine:
                // if it is the explode the mine
                if (cell.exploded)
                {
                    return tileExploded;
                }
                // all the normal mines
                    return tileMine;
            // assign number
            case Cell.Type.Number: return GetNumberTile(cell); 
                default: return null;
        }
    }

    private Tile GetNumberTile(Cell cell)
    {
        switch (cell.number)
        {
            case 1: return tileNum1;
            case 2: return tileNum2;
            case 3: return tileNum3;
            case 4: return tileNum4;
            case 5: return tileNum5;
            case 6: return tileNum6;
            case 7: return tileNum7;
            case 8: return tileNum8;
            default: return null;
        }
    }
}
