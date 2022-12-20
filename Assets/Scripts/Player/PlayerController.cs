using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    private Animator animator;
    public float moveSpeed = 5f;
    Vector2 input;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        if (input.x >= 0)
            gameObject.transform.localScale = new Vector3(1, 1, 1);


        if (input.x < 0) gameObject.transform.localScale = new Vector3(-1, 1, 1);
        animator.SetFloat("Horizontal", Mathf.Abs(input.x));
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
    }
}
