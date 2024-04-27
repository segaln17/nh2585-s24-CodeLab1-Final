using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PrayerScript : MonoBehaviour

//get a list of scriptable objects
//get an array of sounds
//on click of each button, sound gets added to queue
//finish up prayer function will dequeue in order and choose a scriptable object from the list
//prayers chosen will add scriptable objects to the list and pull the top one that was added?

{
    //private Queue<AudioClip> prayerQueue;
    //TODO: implement enqueuing of sound effects & get sound effects
    //TODO: fill out Indulgence();
    
    //PLACEHOLDER queue:
    private Queue<string> prayerQueue = new Queue<string>();

    public List<CharacterScriptableObject> godList = new List<CharacterScriptableObject>();

    public TextMeshProUGUI displayText; //for displaying queue text while it's still text
    public TextMeshProUGUI priestText; //what the priest says
    public TextMeshProUGUI godResultText; //text that displays the god who answers your prayer

    public CharacterScriptableObject loveGod;
    public CharacterScriptableObject rotGod;
    public CharacterScriptableObject centiGod;
    public CharacterScriptableObject demonGod;
    
    // Start is called before the first frame update
    void Start()
    {
        displayText.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //pull a sound from an array of sounds and queue it?
    //if not sounds it will be coded to different phrases and Prayer will be more than one function
    //the god associated with the first prayer queued is the one who answers
    
    //prayers are coded to specific gods?
    public void LoveGodPrayer()
    { 
        //queue a specific sound or phrase
       //add LoveGod to the godList? or make it also a queue?
       prayerQueue.Enqueue("I pray for the adoration of the many.");
       godList.Add(loveGod);
    }

    public void RotGodPrayer()
    {
        prayerQueue.Enqueue("I pray for a peaceful decomposition.");
        godList.Add(rotGod);
    }

    public void CentiGodPrayer()
    {
        prayerQueue.Enqueue("I pray to be wiggly and wriggly!");
        godList.Add(centiGod);
    }

    public void DemonGodPrayer()
    {
        prayerQueue.Enqueue("I pray... to anyone who will listen, if there is anyone left.");
        godList.Add(demonGod);
    }

    public void FinishPrayer()
    {
        //this will pick a Scriptable Object from the god array and display the god's name and response
        //also display queue:
        ShowQueueEffects();
        priestText.text = "The divine speaks through me:";
        godResultText.gameObject.SetActive(true);
        godResultText.text = godList[0].godDialogue;
    }

    void ShowQueueEffects()
    {
        //while there are things in the queue, show them:
        while (prayerQueue.Count > 0)
        {
            displayText.text += "\n" + prayerQueue.Dequeue();
        }
    }

    public void Indulgence()
    {
        if (GameManagerScript.instance.money >= 5)
        {
            priestText.text = "With this certificate, you'll surely go to heaven! \nAnd I'll finally be able to afford my Falcon 7X jet! \nSame model as my favorite pop star. \nYAHOOO!!!";
            if (GameManagerScript.instance.money >= 5)
            {
                GameManagerScript.instance.money -= 5;
            }
            else
            {
                GameManagerScript.instance.money = 0;   
            }
        }
        else
        {
            priestText.text = "Oh, you're poor... You're probably going to hell.";
        }
        //TODO: use money to buy indulgence and update priestText to say you're going to heaven
    }
}
