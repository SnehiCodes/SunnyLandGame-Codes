using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : Enemy
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
            if(transform.localScale.x != -1)
                {
                    transform.localScale = new Vector3(-1,1);
                }

                if(coll.IsTouchingLayers(ground))
                {
                    rb.velocity = new Vector2(-4,1);
                    anim.SetBool("IsRunning",true) ;
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
                    if(transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1,1);
                }

                if(coll.IsTouchingLayers(ground))
                {
                    rb.velocity = new Vector2(4,1);
                    anim.SetBool("IsRunning",true) ;
                }
            }
            else
            {
                facingLeft = true;
            }
        
    }
    }
public void JumpedOn()
{
    anim.SetTrigger("Death");
}

private void Death()
{
    Destroy(this.gameObject);
}

}
