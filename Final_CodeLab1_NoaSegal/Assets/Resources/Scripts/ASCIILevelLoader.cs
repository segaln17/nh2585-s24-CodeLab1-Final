using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using File = System.IO.File;

public class ASCIILevelLoader : MonoBehaviour
{
    public static ASCIILevelLoader Instance;

    private GameObject level;

    public int currentLevel = 0;

    private string FILE_PATH;
    //TODO: make GameManagerScript

    public TextMeshProUGUI demonText;
    
    //Property to change levels:
    public int CurrentLevel
    {
        get
        {
            return currentLevel;
        }
        set
        {
            currentLevel = value;
            LoadLevel();
        }
    }

    //singleton behavior:
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //set file path to get the text files for the ASCII level loader:
        FILE_PATH = Application.dataPath + "/Resources/Levels/LevelNum.txt";
        LoadLevel();
    }

    public void LoadLevel()
    {
        Debug.Log("next level");
        
        //get rid of the last one
        Destroy(level);
        
        //create a new gameObject parent to hold everything from the level
        level = new GameObject("Level Objects");
        new GameObject("debugObject");

        //create an array of strings to contain the level contents from the text file
        //update based on file name
        string[] lines = File.ReadAllLines(FILE_PATH.Replace("Num", currentLevel + ""));

        //loop through the array of strings and through the characters in each line
        for (int yLevelPos = 0; yLevelPos < lines.Length; yLevelPos++)
        {
            //get a single line and convert to upper case:
            string line = lines[yLevelPos].ToUpper();

            char[] characters = line.ToCharArray();

            for (int xLevelPos = 0; xLevelPos < characters.Length; xLevelPos++)
            {
                char c = characters[xLevelPos];
                //Debug.Log(c);

                GameObject newObject = null;
                
                //instantiate the prefabs based on what character it is
                switch (c)
                {
                    case 'W': //wall
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Wall"));
                        break;
                    
                    //player
                    case 'P':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
                        //parent main camera to player with slight offset:
                        Camera.main.transform.parent = newObject.transform;
                        Camera.main.transform.position = new Vector3(0, 0, -20);
                        break;
                    
                    //coin
                    case 'C':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Coin"));
                        break;
                    
                    //demon? (hazard, makes you lose 1 coin)
                    case 'D':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Demon"));
                        //TODO: demonText does not appear over the demon prefabs
                        demonText.transform.parent = newObject.transform;
                        demonText.transform.position = new Vector3(10, 10, 0);
                        break;
                    
                    //boba shop (temptation, takes you to a different scene and you can spend your coins)
                    case 'B':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/BobaShop"));
                        break;
                    
                    //exit (next level)
                    case 'E':
                        break;
                    
                    //church (end goal)
                    case 'G':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Church"));
                        break;
                }
                //if there is a new object, parent it to the gameObject parent
                if (newObject != null)
                {
                    newObject.transform.parent = level.transform;
                    
                    //build the level based on the character positions, and make it backwards
                    newObject.transform.position = new Vector3(xLevelPos, -yLevelPos);
                }

            }
        }
    }


}
