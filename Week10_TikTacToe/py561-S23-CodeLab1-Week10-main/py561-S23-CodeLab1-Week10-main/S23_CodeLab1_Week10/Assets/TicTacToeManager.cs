using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicTacToeManager : MonoBehaviour
{
    public Button[][] buttons = new Button[3][];
    public Text[][] buttonTexts = new Text[3][];
    private int[][] gameBoard = new int[3][];
    private int currentPlayer = 1; // 1 for Player 1 (O), -1 for Player 2 (X)
    private int moveCount = 0;
    public Text statusText;
    
    private void Awake()
    {
        for (int i = 0; i < 3; i++)
        {
            buttons[i] = new Button[3];
            buttonTexts[i] = new Text[3];
            gameBoard[i] = new int[3];
        }

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                buttons[i][j] = GameObject.Find("button_" + i + "_" + j).GetComponent<Button>();
                buttonTexts[i][j] = buttons[i][j].GetComponentInChildren<Text>();
                gameBoard[i][j] = 0;
            }
        }
    }
    
    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                int x = i;
                int y = j;
                buttons[i][j].onClick.AddListener(() => OnButtonClick(x, y));
            }
        }
    }
    
    private void OnButtonClick(int x, int y)
    {
        if (gameBoard[x][y] == 0)
        {
            gameBoard[x][y] = currentPlayer;
            buttonTexts[x][y].text = currentPlayer == 1 ? "O" : "X";
            moveCount++;

            if (CheckWinner(x, y))
            {
                statusText.text = "Player " + (currentPlayer == 1 ? "1" : "2") + " wins!";
                DisableAllButtons();
            }
            else if (moveCount == 9)
            {
                statusText.text = "It's a draw!";
                DisableAllButtons();
            }
            else
            {
                currentPlayer *= -1;
                statusText.text = "Player " + (currentPlayer == 1 ? "1" : "2") + "'s turn!";
            }
        }
    }
    
    private bool CheckWinner(int x, int y)
    {
        if (gameBoard[x][0] == currentPlayer && gameBoard[x][1] == currentPlayer && gameBoard[x][2] == currentPlayer) // Row
            return true;
        if (gameBoard[0][y] == currentPlayer && gameBoard[1][y] == currentPlayer && gameBoard[2][y] == currentPlayer) // Column
            return true;
        if (x == y && gameBoard[0][0] == currentPlayer && gameBoard[1][1] == currentPlayer && gameBoard[2][2] == currentPlayer) // Diagonal
            return true;
        if (x + y == 2 && gameBoard[0][2] == currentPlayer && gameBoard[1][1] == currentPlayer && gameBoard[2][0] == currentPlayer) // Anti-Diagonal
            return true;
        return false;
    }
    
    private void DisableAllButtons()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                buttons[i][j].interactable = false;
            }
        }
    }
}

