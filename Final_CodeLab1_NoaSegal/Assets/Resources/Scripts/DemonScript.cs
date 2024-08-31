using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DemonScript : MonoBehaviour
{
    //public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //when the player hits a demon, they lose money and their text gets updated
    private void OnCollisionEnter(Collision other)
    {
        GameManagerScript.instance.money--;
        Instantiate(GameManagerScript.instance.demonEffect, transform.position, transform.rotation);
        GameManagerScript.instance.dialogueText.text = "A demon?! It stole my money... I was going to buy indulgences, or maybe boba...";
    }
}
