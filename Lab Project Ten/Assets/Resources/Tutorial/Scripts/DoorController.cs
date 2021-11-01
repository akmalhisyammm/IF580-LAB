using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    Animator doorAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") doorAnimator.SetBool("isOpening", true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") doorAnimator.SetBool("isOpening", false);
    }

    void Awake()
    {
        doorAnimator = this.transform.parent.GetComponent<Animator>();   
    }
}
