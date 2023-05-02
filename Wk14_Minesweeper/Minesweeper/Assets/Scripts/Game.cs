using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour
{
    // size of the actual gameboard
    [SerializeField] int width = 16;
    [SerializeField] int height = 16;

    private GameBoard _gameBoard;
    private Cell[,] state;

    // total number of mines on the board
    [SerializeField] private int mineCount = 32;
    
    private void Awake()
    {
        // to call the draw function from children
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
        
        // LAYER 0: generate all the cells on the base layer
        GenerateCells();
        // LAYER 1: add mines randomly on the cells
        GenerateMines();
        // LAYER 2: generate number cells based on mine
        GenerateNumbers();
        
        // camera offset: center the board by adjusting camera
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
    
    // LAYER 2: Generate mines on top of cell layer
    // 生成炸弹
    private void GenerateMines()
    {
        // looping through all mines to generate mines
        for (int i = 0; i < mineCount; i++)
        {
            int x = Random.Range(0, width);
            int y = Random.Range(0, height);
            
            // avoid mine already existing
            while (state[x,y].type == Cell.Type.Mine)
            {
                // move to the next cell
                x++;
                // if x reaches the end of the row
                if (x >= width)
                {
                    // move to the beginning of the following column
                    x = 0;
                    y++;
                    // 当y reach至最后依然没有空隙，y归零重新开始loop
                    if (y >= height)
                    {
                        y = 0;
                    }
                }
            }

            // change state of the cell on selective position
            state[x, y].type = Cell.Type.Mine;
            // 测试内容，显示state
            // state[x, y].revealed = true;
        }
    }
    
    // LAYER 3: Generate numbers
    // 继续loop through整个grid，对于没有mines 的cell生成周围有几颗mine的数字
    private void GenerateNumbers()
    {
        for (int x = 0; x < width; x++) 
        {
            for (int y = 0; y < height; y++)
            {
                // pull out each cell in the loop
                Cell cell = state[x, y];
                
                // skip the generate number action if the cell is a mine
                if (cell.type == Cell.Type.Mine)
                {
                    continue;
                }
                // 如果不是mine，需要在cell上显示数字
                cell.number = CountMines(x, y);
                if (cell.number > 0)
                {
                    cell.type = Cell.Type.Number;
                }
                
                // state the changes
                state[x, y] = cell;
                // 测试，显示state
                // state[x, y].revealed = true;
            }
        }
    }

    // Part of LAYER 3
    // count mines nearby the empty cell
    // 检查cell四周是否有mines
    private int CountMines(int cellX, int cellY)
    {
        // initial count for mines around is 0
        int count = 0;

        // for x, check from -1 to 1 of that cell
        for (int disX = -1; disX <= 1; disX++)
        {
            // for y, check from -1 to 1 of that cell
            for (int disY = -1; disY <= 1; disY++) 
            {
                // no need to check on the cell, 不可能是mine
                if (disX == 0 && disY == 0)
                {
                    continue;
                }

                int x = cellX + disX;
                int y = cellY + disY;
                
                // 排除exception即x和y在grid边缘之外
                // boundary不能小于0或者超过width
                if (x < 0 || x >= width || y < 0 || y >= height)
                {
                    // skip the cell
                    continue;
                }

                if (state[x, y].type == Cell.Type.Mine)
                {
                    count++;
                }
            }
        }

        return count;
    }

    // Check for mouse button click
    private void Update()
    {
        // right click to trigger flag
        if (Input.GetMouseButtonDown(1))
        {
            Flag();
        }
    }

    private void Flag()
    {
        // get the position for mouse input
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // mouse的worldPosition定位在cell上 
        Vector3Int cellPosition = _gameBoard.tilemap.WorldToCell(worldPosition);
        // get the cell at the clicked mouse position
        Cell cell = GetCell(cellPosition.x, cellPosition.y);
        
        // check the validity of the cell
        if (cell.type == Cell.Type.Invalid)
        {
            return;
        }
        
        // if there is a pointed cell, change flag status
        cell.flagged = !cell.flagged;
        state[cellPosition.x, cellPosition.y] = cell;
    }

    // get the clicked cell position
    private Cell GetCell(int x, int y)
    {
        // if the clicked position IS in the cell grid
        if (IsValid(x, y))
        {
            return state[x, y];
        }
        // if the clicked position is NOT in the cell grid
        else
        {
            // set the cell to be a invalid cell
            return new Cell();
        }
    }

    // 判断mouse click是否在cell内
    private bool IsValid(int x, int y)
    {
        // if mouse click is within the boundary of cell
        if (x > 0 && x < width && y > 0 && y < height)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
