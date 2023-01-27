using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCharacterMovement2 : MonoBehaviour
{

    public Rigidbody2D rb;
    public float jumpAmount = 10;
    public float MoveSpeed;
    private bool facingRight = true;
    private float moveDirection;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        //GetInputs
        processInput();
        
        //Animate
        Animate();
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }
    }
    

    private void FixedUpdate()
    {
        //Move
        Move();
    }
    
    private void Move()
    {
        rb.velocity = new Vector2(moveDirection * MoveSpeed, rb.velocity.y);
    }
    
    private void Animate()
    {
        if (moveDirection > 0 && !facingRight)
        {
            FlipCharacter();
        }
        else if (moveDirection < 0 && facingRight)
        {
            FlipCharacter();
        }
    }

    private void processInput()
    {
        moveDirection = Input.GetAxis("Horizontal");
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

}