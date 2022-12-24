using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    private Animator animator;
    public float moveSpeed = 5f;
    private float stamina = 1000f;
    Vector2 input;
    Rigidbody2D rb;
    bool m_FacingRight = true;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (stamina > 0)
            {
                StaminaController.Use(2f);
                moveSpeed = 10;
                stamina--;

            }
            else
            {
                moveSpeed = 5;
            }

        }
        else
        {
            if(stamina<1000)    stamina+=0.25f;
            moveSpeed = 5;
            StaminaController.RestoreStamina(0.25f);
        }
        HandleInput();
        HandleAnimations();
    }

    private void HandleAnimations()
    {
        if (input.x > 0 && !m_FacingRight)
            Flip();
        else if (input.x < 0 && m_FacingRight)
            Flip();

        animator.SetFloat("Horizontal", input.x);
        animator.SetFloat("Vertical", input.y);
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void HandleInput()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");


    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + input * moveSpeed * Time.fixedDeltaTime);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnterRestaurant")
        {
            SceneManager.LoadScene("Restaurant");
        }
        else if (collision.tag == "LeaveRestaurant")
        {
            SceneManager.LoadScene("Street");
        }
        else if (collision.tag == "Police")
        {
            SceneManager.LoadScene("You loose");
        }
    }
}
