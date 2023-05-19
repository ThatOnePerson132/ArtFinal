using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SpriteRenderer sr;
    public Rigidbody2D rb;
    public float moveSpeed;
    public float horizontalInput;
    public bool isOnGround = true;
    public float jumpForce;
    public float lowerLimit;
    public GameManager gm;
    public Animator animator;


    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        if (transform.position.y < lowerLimit)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Respawn();
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * moveSpeed * horizontalInput * Time.deltaTime);
        animator.SetFloat("moveSpeed", Mathf.Abs(horizontalInput));
        if (horizontalInput <= 0)
        {
            sr.flipX = true;
        }
        else if (horizontalInput >= 0)
        {
            sr.flipX = false;
        }
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            isOnGround = false;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    public void Hurt()
    {
        gm.Respawn();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isOnGround = true;
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
