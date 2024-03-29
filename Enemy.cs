using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Animator anim;
    protected Rigidbody2D rb;
    protected AudioSource death;

    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        death = GetComponent<AudioSource>();
    
    }
    public void JumpedOn()
    {
        anim.SetTrigger("Death");
        death.Play();
        enemyScript.scoreValue +=1;
        rb.velocity = Vector2.zero;
    }
    private void Death()
    {
        
        Destroy(this.gameObject);
        
    }
}
