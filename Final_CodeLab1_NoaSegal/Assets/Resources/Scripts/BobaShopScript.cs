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
//THIS DOES NOT CURRENTLY WORK:
    private void OnTriggerEnter(Collider other)
    {
        //TODO: why is this not triggering? they both have colliders...
        Debug.Log("Boba time!");
        SceneManager.LoadScene("Scenes/BobaScene");
    }
}
