using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 100.0f;
    Animator anim;

    void Awake()
    {
        anim = this.GetComponent<Animator>();    
    }

    void FixedUpdate()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.fixedDeltaTime;
        rotation *= Time.fixedDeltaTime;

        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if (translation != 0)
        {
            anim.SetBool("isWalking", true);
            anim.SetFloat("characterSpeed", translation);
        } 
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetFloat("characterSpeed", 0);
        }
    }
}
