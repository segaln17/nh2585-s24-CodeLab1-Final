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
    //TODO: display scriptable object names and descriptions
    
    //PLACEHOLDER queue:
    private Queue<string> prayerQueue = new Queue<string>();

    public List<CharacterScriptableObject> godList = new List<CharacterScriptableObject>();

    public TextMeshProUGUI displayText; //for displaying queue text while it's still text
    
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
    
    //prayers are coded to specific gods?
    public void LoveGodPrayer()
    { 
        //queue a specific sound or phrase
       //add LoveGod to the godList? or make it also a queue?
       prayerQueue.Enqueue("I pray for love");
    }

    public void RotGodPrayer()
    {
        prayerQueue.Enqueue("I pray for a peaceful decomposition");
    }
    
    //add more god prayers or cut them down to 4

    public void FinishPrayer()
    {
        //this will pick a Scriptable Object from the god array and display the god's name and response
        //also display queue:
        ShowQueueEffects();
    }

    void ShowQueueEffects()
    {
        //while there are things in the queue, show them:
        while (prayerQueue.Count > 0)
        {
            displayText.text += "\n" + prayerQueue.Dequeue();
        }
    }
}
