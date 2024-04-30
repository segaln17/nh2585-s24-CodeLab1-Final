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
    //at the end there will be a GoToChurch function to just skip right to church because the player character is late

    //text that will display what the player has purchased
    public TextMeshProUGUI possessionsText;
    //text that will update the player's dialogue
    public TextMeshProUGUI dialogueText;

    //the button that will load the church scene
    public Button churchButton;

    //the money possessed by the player, mostly for debugging purposes without having to play through the whole ASCII level
    public int myMoney;
    //public TextMeshProUGUI moneyText;
    
    //dictionary to represent boba bought:
    public Dictionary<string, int> bobaOwned = new Dictionary<string, int>();
    
    // Start is called before the first frame update
    void Start()
    {
        //sets churchbutton to inactive
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

    }
    
    //checks to see if player has enough money for a boba shop item:
    public bool HasEnoughMoney(int myMoney, int cost)
    {
        //if the player has less money than the item costs
        if (myMoney < cost)
        {
            //dialogueText.text = "I don't have enough money...";
            return false;
        }
        return true;
    }

    //removes money if the player has enough of it to buy something
    public bool RemoveMoney(int myMoney, int cost)
    {
        //first checks to make sure the player has enough money, and if they don't, return false
        if (!HasEnoughMoney(myMoney, cost))
        {
            //Debug.Log("too poor");
            
            return false;
        }
        //if player has enough money, subtract cost from the money possessed and return true
        myMoney = myMoney - cost;
        Debug.Log(myMoney);
        
        return true;
        
    }
    
    
    //displays items purchased
    public void DisplayItems()
    {
        //each new item will be on a new line
        possessionsText.text = "Boba haul: \n";

        //for each item owned, update the text to display the item and its amount that the player has
        foreach (var keyValuePair in bobaOwned)
        {
            possessionsText.text += "\n" + keyValuePair.Key + " (" + bobaOwned[keyValuePair.Key] + ")";
        }
    }

    //function used to buy items
    public void BuyItem(string item)
    {
        //assumes the purchase is not successful as default
        var successfulPurchase = false;

        
        //switch case for each key value pair
        //if the purchase is successful, remove that amount of money
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

        //if the purchase is successful (if that key is in the dictionary), add an instance of it
        if (successfulPurchase)
        {
            if (bobaOwned.ContainsKey(item))
            {
                bobaOwned[item] = bobaOwned[item] + 1;
            }
            
            //if it's not in the dictionary, add it
            else
            {
                bobaOwned.Add(item, 1);
            }
            //update the dialoguetext to prompt the player
            dialogueText.text = "I'm late for church! \nBut I could get more boba...";
        }
        //if the player doesn't have enough money to make a purchase, update the dialoguetext accordingly
        else
        {
            dialogueText.text = "I don't have enough money... :(";
            //Debug.Log("too poor pt 2");
        }
        //after a purchase is made, set the church button to active
        churchButton.gameObject.SetActive(true);
    }
    
    //if church button is clicked, go to the church scene
    public void GoToChurch()
    {
        SceneManager.LoadScene("ChurchScene");
    }
}
