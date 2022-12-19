using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    Vector2 input;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
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
        if(collision.tag == "EnterRestaurant")
        {
            SceneManager.LoadScene("Restaurant");
        }
        else if(collision.tag == "LeaveRestaurant")
        {
            SceneManager.LoadScene("Street");
        }
    }
}
