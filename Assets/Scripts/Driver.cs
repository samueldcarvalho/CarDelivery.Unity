using System;
using TMPro;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField]
    private float _directionSpeed = 50f;
    [SerializeField]
    private float _moveSpeed = 50f;

    [SerializeField]
    private float _fuel = 100f;
    [SerializeField]
    private float _fuelConsumeSpeed = 1.0f;

    private void Start()
    {
        FinishEndpointBehaviour.OnCarFinished += FinishEndpointBehaviour_OnCarFinished;
    }

    void Update()
    {
        CheckFuel();

        if(_fuel > 0)
        {
            float moveAmount = Input.GetAxis("Vertical") * _moveSpeed * Time.deltaTime;
            float directionAmount = -Input.GetAxis("Horizontal") * _directionSpeed * Input.GetAxis("Vertical") * Time.deltaTime;

            transform.Rotate(0, 0, directionAmount);
            transform.Translate(0, moveAmount, 0);
        }
    }

    private void CheckFuel()
    {
        if (_fuel <= 0)
        {
            _fuel = 0;
            return;
        }
        
        if(Input.GetAxis("Vertical") > 0)
        {
            _fuel -= _fuelConsumeSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Consumable")
        {
            _fuel += collision.GetComponent<Fuel>().FuelAmount;
            Destroy(collision.gameObject);
        }
    }

    private void FinishEndpointBehaviour_OnCarFinished()
    {
        _fuel = 0;
    }
}
