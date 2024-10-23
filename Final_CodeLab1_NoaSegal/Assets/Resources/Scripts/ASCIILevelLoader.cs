using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using File = System.IO.File;

public class ASCIILevelLoader : MonoBehaviour
{
    //making the ASCIILevelLoader a singleton
    public static ASCIILevelLoader Instance;

    //level that is set within this script
    private GameObject level;

    //current level index
    public int currentLevel = 0;

    //file path for saving the level and loading it
    private string FILE_PATH;
    
    //text that ideally would appear above the demons in-level (does not currently)
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

        Resources.Load("Level0");
        //load the level from the text file:
        LoadLevel();
    }

    public void LoadLevel()
    {
        //Debug.Log("next level");
        
        //get rid of the previous level
        Destroy(level);
        
        //create a new gameObject parent to hold everything from the level
        level = new GameObject("Level Objects");
        //new GameObject("debugObject");

        //create an array of strings to contain the level contents from the text file
        //update based on file name
        //string[] lines = File.ReadAllLines(FILE_PATH.Replace("Num", currentLevel + ""));
        string[] lines = Resources.Load<TextAsset>("Level0").text.Split('\n');

        //loop through the array of strings and through the characters in each line
        for (int yLevelPos = 0; yLevelPos < lines.Length; yLevelPos++)
        {
            //get a single line and convert to upper case:
            string line = lines[yLevelPos].ToUpper();

            char[] characters = line.ToCharArray();

            for (int xLevelPos = 0; xLevelPos < characters.Length; xLevelPos++)
            {
                //add the character to the array of characters at this position
                char c = characters[xLevelPos];
                //Debug.Log(c);

                //default case if there is no character:
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
                        Camera.main.transform.position = new Vector3(0, 0, -15);
                        break;
                    
                    //coin
                    case 'C':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Coin"));
                        break;
                    
                    //demon (hazard, makes you lose 1 coin)
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
                    
                    //church (end goal)
                    case 'G':
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Church"));
                        break;
                    
                    //exit (next level --> would be implemented if I added another level)
                    case 'E':
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
