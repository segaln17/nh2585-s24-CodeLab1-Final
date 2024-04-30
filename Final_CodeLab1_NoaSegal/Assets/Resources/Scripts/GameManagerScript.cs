using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    //declares GameManagerScript as a singleton
    public static GameManagerScript instance;

    //declares and initializes money variable
    public int money = 0;
    //text displaying the money
    public TextMeshProUGUI moneyText;
    //text that displays the dialogue and is updated in script
    public TextMeshProUGUI dialogueText;

    
    //singleton behavior
    private void Awake()
    {
        //if there arent any others of these, keep it
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        //otherwise, destroy it
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //initial dialoguetext
        dialogueText.text = "It sure is a nice day! I oughta get to church!";
    }

    // Update is called once per frame
    void Update()
    {
        //update the moneytext with the amount of money currently had
        moneyText.text = "Money: " + money;
    }
    
}
