using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive2 : MonoBehaviour
{
    float speed = 5f;
    float rotationSpeed = 100f;
    float currentSpeed = 0.0f;
    Animator animator;

    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") *speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        currentSpeed += translation;
        animator.SetFloat("Speed", currentSpeed);
        transform.Rotate(0,rotation,0); 

        if(translation!=0){
            animator.SetBool("isWalking", true);
        }else{
            animator.SetBool("isWalking", false);
            currentSpeed = 0;
        }
    }
}
