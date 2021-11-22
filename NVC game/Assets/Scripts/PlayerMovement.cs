using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public ParticleSystem walkEffect;
    public string verticalInputAxis = "Vertical";
    public string horizontalInputAxis = "Horizontal";
    Animator animator;
    SpriteRenderer rend;
    bool isInsideLayout = true;
    void Start()
    {
        animator = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis(horizontalInputAxis) * speed * Time.deltaTime;
        float y = Input.GetAxis(verticalInputAxis) * speed * Time.deltaTime;

        transform.Translate(x * Mathf.Sign(x), y, 0);

        float rotationState = Mathf.Sign(x) < 0 ? 1 : 0;
        transform.rotation = Quaternion.Euler(0, 180 * rotationState, 0);

        animator.SetFloat("Speed", Mathf.Abs(x) + Mathf.Abs(y));

        if(Mathf.Abs(x) + Mathf.Abs(y) > 0)
        {
            walkEffect.enableEmission = true;
            
        } else {
            walkEffect.enableEmission = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Frame")
        {
            isInsideLayout = false;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.tag == "Frame")
        {
            isInsideLayout = true;
        }    
    }
}
