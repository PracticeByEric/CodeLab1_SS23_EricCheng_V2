using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// data structure for each individual cell
public struct Cell
{
    public enum Type
    {
        Empty,
        Mine,
        Number,
    }

    // position of each cell
    public Vector3Int position;
    // type of each cell
    public Type type;
    public int number;
    
    // different states of the cell
    public bool revealed;
    public bool flagged;
    public bool exploded;
}
