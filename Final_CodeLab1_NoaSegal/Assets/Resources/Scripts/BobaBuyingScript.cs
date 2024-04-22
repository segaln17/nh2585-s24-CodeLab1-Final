using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BobaBuyingScript : MonoBehaviour
{
    //TODO: this will pull from GameManagerScript.instance.money and use that value to get items from a dictionary
    //boba items in the dictionary will have prices keyed to them
    //clicking buttons will get those things and subtract the corresponding money
    //at the end there will be a GoToChurch function to just skip right to church because the main character is late
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToChurch()
    {
        SceneManager.LoadScene("ChurchScene");
    }
}
