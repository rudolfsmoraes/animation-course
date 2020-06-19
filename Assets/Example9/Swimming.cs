using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swimming : MonoBehaviour
{
    float speed = 5f;
    float rotationSpeed = 100f;
    float currentSpeed = 0f;
    Animator animator;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
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
        animator.SetFloat("Speed", Mathf.Clamp(currentSpeed,0f,5f));
        transform.Rotate(0,rotation,0); 

        if(translation!=0){
            animator.SetBool("isSwimming", true);
        }else{
            animator.SetBool("isSwimming", false);
            currentSpeed = 0;
        }

        if(Input.GetKeyDown("space")){
            animator.SetTrigger("isJumping");
        }
    }
}
