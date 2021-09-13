using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Declare Spin Speed and Movement Speed
    public float spinSpeed;
    public float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        // Gives initial value for Spin Speed and Movement Speed
        spinSpeed = 90f;
        movementSpeed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(Vector3.left * spinSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(Vector3.right * spinSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.down * spinSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(transform.forward * movementSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-transform.right * movementSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-transform.forward * movementSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(transform.right * movementSpeed * Time.deltaTime, Space.World);
        }
    }
}
