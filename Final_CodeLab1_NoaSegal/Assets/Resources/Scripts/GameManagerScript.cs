using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;

    public int money = 0;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI dialogueText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
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
        dialogueText.text = "It sure is a nice day! I oughta get to church!";
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "Money: " + money;
    }
    
}
