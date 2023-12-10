using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishEndpointBehaviour : MonoBehaviour
{
    public static event Action OnCarFinished;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("CAR FINISHED!");
            OnCarFinished();
        }
    }
}
