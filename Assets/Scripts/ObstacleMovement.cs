using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public Transform gfxTransform;
    
    [SerializeField] private float maxRotationSpeed = 90f;
    [SerializeField] private float maxSpeed = 40f;
    
    private float _speed = 10f;
    private float _rotationSpeed = 15f;

    private void OnEnable()
    {
        _speed = UnityEngine.Random.Range(1f, maxSpeed);
        _rotationSpeed = UnityEngine.Random.Range(10f, maxRotationSpeed);
    }

    private void Update()
    {
        transform.Translate(Vector3.back * (_speed * Time.deltaTime));
        gfxTransform.Rotate(Vector3.right, _rotationSpeed * Time.deltaTime);
    }
}
