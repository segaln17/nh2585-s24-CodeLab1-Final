using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChurchScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //when the player collides with the church, go to the church scene
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Church!");
        SceneManager.LoadScene("Scenes/ChurchScene");
    }
}
