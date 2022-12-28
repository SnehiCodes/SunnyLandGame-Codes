using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opossum : Enemy
{
    [SerializeField] private float leftCap ;
    [SerializeField] private float rightCap ;
     
    //[SerializeField] private float jumpLength = 10f;
    //[SerializeField] private float jumpHeight = 15f;
    [SerializeField] private LayerMask ground;
    private Collider2D coll;

    private bool facingLeft = true;

    [SerializeField] private float speed;

    
    protected override void Start()
    {
        base.Start();
        coll = GetComponent<Collider2D>();
        
    }

    private void Update()
    {
        //transform.position += new Vector3(1,0,0)*speed*Time.deltaTime ;
        Move();
    }
    private void Move()
    {
        if(facingLeft)
        {
            if(transform.position.x>leftCap)
            {
            if(transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1,1);
                }

                if(coll.IsTouchingLayers(ground))
                {
                    transform.position += new Vector3(-1,0,0)*speed*Time.deltaTime ;
                    anim.SetBool("Jumping",true) ;
                }
            
            }
            else
            {
                facingLeft = false;
            }
        }

            else
            {
                if(transform.position.x<rightCap)
                {
                    if(transform.localScale.x != -1)
                {
                    transform.localScale = new Vector3(-1,1);
                }

                if(coll.IsTouchingLayers(ground))
                {
                    transform.position += new Vector3(1,0,0)*speed*Time.deltaTime ;
                    anim.SetBool("Jumping",true) ;
                }
            }
            else
            {
                facingLeft = true;
            }
        
    }
    }}
   

    

