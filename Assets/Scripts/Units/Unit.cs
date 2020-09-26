using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType { Zombie, Human, Player}
public class Unit : MonoBehaviour
{
    public float speed = .2f;
    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer sr;

    public virtual void InitializeUnit()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
  
    // Update is called once per frame
    public virtual void UpdateUnit()
    {
        Vector2 moveDir = GetMoveDir();
        UpdateAnimator(moveDir);
        sr.sortingOrder = (int)(transform.position.y * 10);
    }

    public void FixedUpdateUnit()
    {
        Vector2 moveDir = GetMoveDir();
        Move(moveDir);
    }

    protected virtual Vector2 GetMoveDir()
    {
        return new Vector2(); //Meant to be overriden by child, Could make it abstract
    }

    protected virtual void UpdateAnimator(Vector2 dir)
    {
        bool yIsGreater = (Mathf.Abs(dir.y) > Mathf.Abs(dir.x));
        if(yIsGreater)
        {
            animator.SetFloat("HorzAxis", 0);
            animator.SetFloat("VertAxis", dir.y);
        }
        else
        {
            animator.SetFloat("HorzAxis", dir.x);
            animator.SetFloat("VertAxis", 0);
        }
        
    }

    private void Move(Vector2 dir)
    {
        rb.velocity = dir.normalized*speed;
    }

}
