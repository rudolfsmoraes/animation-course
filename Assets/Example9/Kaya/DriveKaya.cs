using UnityEngine;
using System.Collections;

public class Drive : MonoBehaviour {

    float speed = 1.0F;
    float rotationSpeed = 100.0F;
    Animator anim;

    void Start()
    {
    	anim = this.GetComponent<Animator>();
    }

    void Update() 
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        rotation *= Time.deltaTime;
        transform.Rotate(0, rotation, 0);

        if(translation != 0)
        {
        	anim.SetBool("isWalking",true);
        }
        else
        {
        	anim.SetBool("isWalking",false);
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("DeathCube")){
            anim.SetBool("isDead", true);
        }
        
    }
}
