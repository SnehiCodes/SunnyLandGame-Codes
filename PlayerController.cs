using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private enum State {idle,running,jumping,falling,hurt}
    private State state  = State.idle;
    private Collider2D coll;
    private AudioSource footstep;

    public int cherries =0;

    [SerializeField]private LayerMask ground;
    [SerializeField]private float speed = 5f;
    [SerializeField]private float  jumpForce = 10f;
    [SerializeField]private float  hurtForce = 10f;    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        footstep = GetComponent<AudioSource>();
    
    }

    private void Update()
    {

        if(state != State.hurt)
        {
            Movement();
        }
        
        AnimationState();
        anim.SetInteger("state",(int)state);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Collectible")
        {
            Destroy(collision.gameObject);
            cherries +=1;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy" )
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if(state == State.falling)
            {
                enemy.JumpedOn();
                Jump();
            }
            else
            {
                state = State.hurt;
                if(other.gameObject.transform.position.x> transform.position.x)
                {
                    rb.velocity = new Vector2(-hurtForce,rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(hurtForce,rb.velocity.y);
                }
            }
            
        }
    }

    private void Movement()
    {
        float hDirection = Input.GetAxis("Horizontal");

        if(hDirection<0)
        {
            rb.velocity = new Vector2(-speed,rb.velocity.y);
            transform.localScale = new Vector2(-1,1);
        }

        else if(hDirection>0)
        {
            rb.velocity = new Vector2(speed,rb.velocity.y);
            transform.localScale= new Vector2(1,1); 
        }

        else
        {
           
        }

        if(Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            Jump();
        }
    }
    

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x,jumpForce);
        state = State.jumping;
    }
    private void AnimationState()
    {
        if(state == State.jumping)
        {
            if(rb.velocity.y < 0.1f)
            {
                state = State.falling;
            }
        }
        else if(state == State.falling)
        {
            if (coll.IsTouchingLayers(ground))
            {
                state = State.idle;
            }
        }
        else if (state == State.hurt)
        {
            if(Mathf.Abs(rb.velocity.x)<0.1f)
            {
                state = State.idle;
            }
        }
        else if(Mathf.Abs(rb.velocity.x)>2f)
        {
            state = State.running;
        }
        else
        {
            state = State.idle;
        }
        
    }
}
