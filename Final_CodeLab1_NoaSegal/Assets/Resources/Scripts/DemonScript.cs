using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        GameManagerScript.instance.money--;
        GameManagerScript.instance.dialogueText.text = "A demon?! Maybe I should sin...";
    }
}
