using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : Enemy
{
    Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name.Equals("Player"))
        rb.isKinematic = false;
    }

   // void OnCollisionEnter2D (Collision col)
   // {
   //     if(col.gameObject.name.Equals("Player"))
    //}

    void Update()
    {
        
    }
}
