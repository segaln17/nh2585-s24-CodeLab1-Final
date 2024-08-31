using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //when the player hits a coin, add money and update display text, then destroy the coin
    private void OnCollisionEnter(Collision other)
    {
        GameManagerScript.instance.money++;
        Instantiate(GameManagerScript.instance.coinEffect, transform.position, transform.rotation);
        GameManagerScript.instance.dialogueText.text = "Wow, a coin! Could use this to save up!";
        Destroy(gameObject);
    }
}
