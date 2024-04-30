using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDScript : MonoBehaviour
{
    //declare rigidbody variable rb
    private Rigidbody rb;

    //amount of force applied to player for movement
    public float forceAmt = 3f;
    // Start is called before the first frame update
    void Start()
    {
        //get the rigidbody of the gameobject that this script is attached to
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //move left
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * forceAmt);
        }

        //move up
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.up * forceAmt);
        }

        //move down
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.down * forceAmt);
        }

        //move right
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * forceAmt);
        }
    }
    
    //resets the text when the player character exits a collision
    private void OnCollisionExit(Collision other)
    {
        GameManagerScript.instance.dialogueText.text = "I oughta get to church!";
    }
}
