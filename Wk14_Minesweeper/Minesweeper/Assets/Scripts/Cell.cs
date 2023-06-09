using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// data structure for each individual cell with in the board
// each cell is a 2d array
public struct Cell
{
    // type of the cell
    public enum Type
    {
        Invalid,
        Empty,
        Mine,
        Number,
    }

    // position of each cell
    public Vector3Int position;
    // type of each cell
    public Type type;
    // number realted to how many bombs nearby
    public int number;
    
    // different states of the cell
    public bool revealed;
    public bool flagged;
    public bool exploded;
}
