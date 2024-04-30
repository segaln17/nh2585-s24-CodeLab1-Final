using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PrayerScript : MonoBehaviour

//get a list of scriptable objects
//make a queue of prayers (strings)
//on click of each button, a prayer gets added to queue
//finish up prayer function will dequeue in order and choose a scriptable object from the list based on the order of prayers
//prayers chosen will add scriptable objects to the list and pull the top one that was added

{
    //original concept: do the same thing but with audio clips instead of strings, but I didn't have time to find and record all the sounds
    //this is how I would have set it up though:
    //private Queue<AudioClip> prayerQueue;
    
    //queue of prayers:
    private Queue<string> prayerQueue = new Queue<string>();

    //list of gods (scriptable objects)
    public List<CharacterScriptableObject> godList = new List<CharacterScriptableObject>();

    public TextMeshProUGUI displayText; //for displaying queue text while it's still text
    public TextMeshProUGUI priestText; //what the priest says
    public TextMeshProUGUI godResultText; //text that displays the god who answers your prayer

    //the scriptable objects assigned to each prayer
    public CharacterScriptableObject loveGod;
    public CharacterScriptableObject rotGod;
    public CharacterScriptableObject centiGod;
    public CharacterScriptableObject demonGod;
    
    // Start is called before the first frame update
    void Start()
    {
        //the display of prayers
        displayText.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    //prayers are coded to specific gods
    public void LoveGodPrayer()
    { 
        //queue a specific phrase
       //add LoveGod to the godList
       prayerQueue.Enqueue("I pray for the adoration of the many.");
       godList.Add(loveGod);
    }

    public void RotGodPrayer()
    {
        //enqueue this phrase
        prayerQueue.Enqueue("I pray for a peaceful decomposition.");
        //add RotGod to the godList in the order queued
        godList.Add(rotGod);
    }

    public void CentiGodPrayer()
    {
        //enqueue this phrase
        prayerQueue.Enqueue("I pray to be wiggly and wriggly!");
        //add CentiGod to the godList in the order queued
        godList.Add(centiGod);
    }

    public void DemonGodPrayer()
    {
        //enqueue this phrase
        prayerQueue.Enqueue("I pray... to anyone who will listen, if there is anyone left.");
        //add DemonGod to the godList in the order queued
        godList.Add(demonGod);
    }

    public void FinishPrayer()
    {
        //this picks a Scriptable Object from the god array (godList) and display the god's response
        //also display queue of prayers:
        ShowQueueEffects();
        //update the priest's text
        priestText.text = "The divine speaks through me:";
        //set this text to be active to display the godDialogue
        godResultText.gameObject.SetActive(true);
        //display the godDialogue of the first scriptable object queued
        godResultText.text = godList[0].godDialogue;
    }

    void ShowQueueEffects()
    {
        //while there are things in the queue, show them:
        while (prayerQueue.Count > 0)
        {
            //each new prayer should appear on a new line
            displayText.text += "\n" + prayerQueue.Dequeue();
        }
    }

    public void Indulgence()
    {
        //if player has 5 or more money, the player can purchase an indulgence
        if (GameManagerScript.instance.money >= 5)
        {
            //updates priestText to explain the purchase
            priestText.text = "With this certificate, you'll surely go to heaven! \nAnd I'll finally be able to afford my Falcon 7X jet! \nSame model as my favorite pop star. \nYAHOOO!!!";
            //subtract the proper amount of money
            if (GameManagerScript.instance.money >= 5)
            {
                GameManagerScript.instance.money -= 5;
            }
            else
            {
                GameManagerScript.instance.money = 0;   
            }
        }
        //if you don't have enough money for an indulgence, update the priestText to tell the player this
        else
        {
            priestText.text = "Oh, you're poor... You're probably going to hell.";
        }
    }
}
