using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    Animator anim;

    public float speed = 5.0f;
    public float rotationSpeed = 100.0f;

    private float defaultSpeed;
    private float speedMultiplier = 2.0f;
    private float translation = 0.0f;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        defaultSpeed = speed;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (translation != 0)
            {
                setRunning(true);
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            setRunning(false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("isJumping", true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("isJumping", false);
        }
    }

    void FixedUpdate()
    {
        translation = Input.GetAxis("Vertical") * speed;
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
            setRunning(false);
            anim.SetFloat("characterSpeed", 0);
        }
    }

    private void setRunning(bool isRunning)
    {
        if (isRunning)
        {
            speed *= speedMultiplier;
            anim.SetBool("isRunning", true);
        }
        else
        {
            speed = defaultSpeed;
            anim.SetBool("isRunning", false);
        }
    }
}
