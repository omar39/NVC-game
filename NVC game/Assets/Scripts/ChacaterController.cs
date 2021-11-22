using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChacaterController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed=5, jumpForce=100;
    public KeyCode jumpKey;
    float speedX, speedY;
    bool isJumping = false;
    Animator animator;
    Rigidbody2D rb;
    int moveDir=0;
    void Start()
    {
        animator =  GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        speedX = (Input.GetAxis("Horizontal") + moveDir) * speed * Time.deltaTime;

       float rotationState = Mathf.Sign(speedX) < 0 ? 1 : 0;
       transform.rotation = Quaternion.Euler(0, 180 * rotationState, 0);

        transform.Translate(speedX * Mathf.Sign(speedX), 0, 0);


        if(Input.GetKeyDown(jumpKey) && !isJumping)
        {
            jump();
        }
        
        animator.SetFloat("Speed", Mathf.Abs(speedX));
        animator.SetBool("IsJumping", isJumping);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.tag == "Ground")
        {
            isJumping = false;
        }
    }
    public void move(int direction)
    {
        moveDir = direction;
    }
    public void stop()
    {
        moveDir = 0;
    }
    public void jump()
    {
        if(!isJumping){
            rb.AddForce(Vector2.up * jumpForce);
            isJumping = true;
        }
    }
}
