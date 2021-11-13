using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleController : MonoBehaviour
{
    private ScoreController scoreController;

    void Awake()
    {
        scoreController = GameObject.FindGameObjectWithTag("ScoreController").GetComponent<ScoreController>();    
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        scoreController.incrementScore();
    }
}
