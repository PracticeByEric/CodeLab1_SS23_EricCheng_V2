using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

public class LevelControl : MonoBehaviour
{
    // assests that scene needs
    public GameObject player;
    public GameObject tree;
    public GameObject treasure;

    // assets in existing scene in
    private GameObject currentPlayer;
    private GameObject level;
    private int currentLevel = 0;

    // ???
    public int CurrentLevel
    {
        get { return currentLevel; }
        set
        {
            currentLevel = value;
            LoadLevel();
        }
    }

    private const string FILE_NAME = "LevelNum.txt";
    private const string FILE_DIR = "/Levels/";
    private string FILE_PATH;

    public float xOffset;
    public float yOffset;

    public Vector2 playerStartPos;

    // Load level at start
    void Start()
    {
        // load file
        FILE_PATH = Application.dataPath + FILE_DIR + FILE_NAME;

        LoadLevel();
    }

    bool LoadLevel()
    {
        Destroy(level);

        level = new GameObject("Level");

        // specify path with level specified
        string newPath = FILE_PATH.Replace("Num", currentLevel + "");
        // get lines out of the array
        string[] fileLines = File.ReadAllLines(newPath);
        
        // go through lines
        for (int yPos = 0; yPos < fileLines.Length; yPos++)
        {
            // turn each line out of the array
            string lineText = fileLines[yPos];
            // each line into array of chars
            char[] lineChars = lineText.ToCharArray();

            for (int xPos = 0; xPos < lineChars.Length; xPos++) 
            {
                // get the current char
                char c = lineChars[xPos];
                
                // make a variable for a new GameObject
                GameObject newObj;

                switch (c)
                {
                    // if p in file. give birth to player
                    case 'p':
                        playerStartPos = new Vector2(xOffset + xPos, yOffset - yPos);
                        newObj = Instantiate<GameObject>(player);
                        break;
                    // if s in file. give birth to square
                    case 's':
                        playerStartPos = new Vector2(xOffset + xPos, yOffset - yPos);
                        newObj = Instantiate<GameObject>(tree);
                        break;
                    case 't':
                        playerStartPos = new Vector2(xOffset + xPos, yOffset - yPos);
                        newObj = Instantiate<GameObject>(treasure);
                        break;
                    default: //otherwise
                        newObj = null; //null
                        break;
                }
                //if we made a new GameObject
                if (newObj != null)
                {
                    //position it based on where it was
                    //in the file, using the variables
                    //we used to loop through our arrays
                    newObj.transform.position =
                        new Vector2(
                            xOffset + xPos, 
                            yOffset - yPos);

                    newObj.transform.parent = level.transform;
                }
                
            }
        }

        return false;
    }

    public void TreasureFound()
    {
        Debug.Log("Treasure found!");
    }

}
