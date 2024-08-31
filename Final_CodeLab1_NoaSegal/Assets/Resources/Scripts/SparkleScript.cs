using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkleScript : MonoBehaviour
{
    public GameObject sparkleEffect;
    // Start is called before the first frame update
    void Start()
    {
        if (this)
        {
            Instantiate(sparkleEffect, transform.position, transform.rotation);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        //sparkleEffect.SetActive(false);
        //Destroy(this);
    }
}
