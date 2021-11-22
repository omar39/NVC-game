using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRun : MonoBehaviour
{
    public float speed = 40f;
    Rigidbody2D rb;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    public void InreaseAccel(float value)
    {
        rb.velocity = new Vector2(rb.velocity.x + (value * Time.fixedDeltaTime), 0);
    }
    public void DecreaseAccel(float value)
    {
        rb.velocity = new Vector2(rb.velocity.x - (value * Time.fixedDeltaTime), 0);
    }
    public void StartRace()
    {
        rb.velocity = new Vector2(speed * Time.fixedDeltaTime, 0);
        animator.SetBool("Run", true);
    }
    public void EndRace()
    {
        rb.velocity = new Vector2(0, 0);
        animator.SetBool("Run", false);
    }
    
}
