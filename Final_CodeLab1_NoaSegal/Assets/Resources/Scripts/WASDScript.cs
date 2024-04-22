using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDScript : MonoBehaviour
{
    private Rigidbody rb;

    public float forceAmt = 3f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * forceAmt);
        }

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.up * forceAmt);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.down * forceAmt);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * forceAmt);
        }
    }
    
    private void OnCollisionExit(Collision other)
    {
        GameManagerScript.instance.dialogueText.text = "I oughta get to church!";
    }
}
