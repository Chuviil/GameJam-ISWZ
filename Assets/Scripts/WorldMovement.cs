using System;
using System.Collections;
using System.Collections.Generic;
using BNG;
using UnityEngine;

public class WorldMovement : MonoBehaviour
{
    [SerializeField] private Lever lever;
    [SerializeField] private SteeringWheel steeringWheel;
    [SerializeField] private float speed = 5f; // Movement speed

    private float _xValue;
    private float _yValue;

    private void Update()
    {
        // Get the input values
        _yValue = (lever.LeverPercentage - 50) / 50;
        _xValue = -steeringWheel.ScaleValue;

        // Move the object
        Move();
    }

    private void Move()
    {
        // Calculate the movement vector
        Vector2 movement = new Vector2(_xValue, _yValue) * (speed * Time.deltaTime);

        // Apply the movement
        transform.Translate(movement);
    }
}