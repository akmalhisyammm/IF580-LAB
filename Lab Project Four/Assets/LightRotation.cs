using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotation : MonoBehaviour
{
    // Declaring Cube and Speed
    public GameObject cube;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the Light
        this.transform.RotateAround(cube.transform.position, cube.transform.up, -90f * Time.deltaTime);
    }
}
