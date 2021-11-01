using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailingController : MonoBehaviour
{
    Animator railingAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") railingAnimator.SetBool("isActivating", true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") railingAnimator.SetBool("isActivating", false);
    }

    void Awake()
    {
        railingAnimator = GameObject.FindGameObjectWithTag("Railing").GetComponent<Animator>();
    }
}
