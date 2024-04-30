using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BobaShopScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
//when the player hits the boba shop, go to the boba shop scene
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Boba time!");
        SceneManager.LoadScene("Scenes/BobaScene");
    }
}
