using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BobaBuyingScript : MonoBehaviour
{
    //this will pull from GameManagerScript.instance.money and use that value to get items from a dictionary
    //boba items in the dictionary will have prices keyed to them
    //clicking buttons will get those things and subtract the corresponding money
    //at the end there will be a GoToChurch function to just skip right to church because the main character is late

    public TextMeshProUGUI possessionsText;
    public TextMeshProUGUI dialogueText;

    public Button churchButton;

    public int myMoney;
    //public TextMeshProUGUI moneyText;
    
    //dictionary to represent boba bought:
    public Dictionary<string, int> bobaOwned = new Dictionary<string, int>();
    
    // Start is called before the first frame update
    void Start()
    {
        churchButton.gameObject.SetActive(false);
        
        //initialize myMoney with the value from the gameManager
        myMoney = GameManagerScript.instance.money;
    }

    // Update is called once per frame
    void Update()
    {
        //display what items you have:
        DisplayItems();
        
        //set the money variable in gameManager so it carries over to the next scene:
        GameManagerScript.instance.money = myMoney;
        
        
        //debug text for testing the code without having to go through the ASCII levels:
        //moneyText.text = myMoney.ToString();

    }
    
    public bool HasEnoughMoney(int myMoney, int cost)
    {
        if (myMoney < cost)
        {
            //dialogueText.text = "I don't have enough money...";
            return false;
        }

        return true;
    }

    public bool RemoveMoney(int myMoney, int cost)
    {
        if (!HasEnoughMoney(myMoney, cost))
        {
            //Debug.Log("too poor");
            
            return false;
        }
        myMoney = myMoney - cost;
        Debug.Log(myMoney);
        
        return true;
        
    }
    
    
    public void DisplayItems()
    {
        possessionsText.text = "Boba haul: \n";

        foreach (var keyValuePair in bobaOwned)
        {
            possessionsText.text += "\n" + keyValuePair.Key + " (" + bobaOwned[keyValuePair.Key] + ")";
        }
    }

    public void BuyItem(string item)
    {
        var successfulPurchase = false;

        switch (item)
        {
            case "Black Milk Tea" :
                successfulPurchase = RemoveMoney(myMoney, 1);
                if (successfulPurchase)
                {
                    myMoney = myMoney - 1;
                }
                break;
            case "Taro Milk Tea" :
                successfulPurchase = RemoveMoney(myMoney, 2);
                if (successfulPurchase)
                {
                    myMoney = myMoney - 2;
                }
                break;
            case "Fruit Tea":
                successfulPurchase = RemoveMoney(myMoney, 2);
                if (successfulPurchase)
                {
                    myMoney = myMoney - 2;   
                }
                break;
            case "Brown Sugar Milk Tea":
                successfulPurchase = RemoveMoney(myMoney, 3);
                if (successfulPurchase)
                {
                    myMoney = myMoney - 3;   
                }
                break;
            case "Extra Tapioca":
                successfulPurchase = RemoveMoney(myMoney, 1);
                if (successfulPurchase)
                {
                    myMoney = myMoney - 1;   
                }
                break;
        }

        if (successfulPurchase)
        {
            if (bobaOwned.ContainsKey(item))
            {
                bobaOwned[item] = bobaOwned[item] + 1;
            }
            
            else
            {
                bobaOwned.Add(item, 1);
            }
            dialogueText.text = "I'm late for church! \nBut I could get more boba...";
        }
        else
        {
            dialogueText.text = "I don't have enough money... :(";
            //Debug.Log("too poor pt 2");
        }
        churchButton.gameObject.SetActive(true);
    }
    
    public void GoToChurch()
    {
        SceneManager.LoadScene("ChurchScene");
    }
}
