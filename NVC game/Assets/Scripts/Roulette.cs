using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roulette : MonoBehaviour
{
    public float rotationSpeed=10;
    Animator animator;
    float currentRotation;
    private void Start() {
        animator = GetComponent<Animator>();
        currentRotation = rotationSpeed;
    }
    private void FixedUpdate() {
        transform.Rotate(0, 0, currentRotation * Time.fixedDeltaTime);   
    }
    bool slowDown()
    {
        currentRotation -= Time.fixedDeltaTime * 100;
        return currentRotation <= 0;
    }
    IEnumerator graduateSpeed(bool isRight)
    {
        currentRotation = 0;

        if(isRight)
        {
            animator.SetTrigger("Right");
        } else {
            animator.SetTrigger("Wrong");
        }
        yield return new WaitForSeconds(1f);
        currentRotation = rotationSpeed;
    }
    public void validateAsRight()
    {
        StartCoroutine( graduateSpeed(true) );
    }
    public void validateAsWrong()
    {
        StartCoroutine( graduateSpeed(false) );
    }

}
