using System;
using System.Collections;
using System.Collections.Generic;
using BNG;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public Slider steeringWheel;

    private void Update()
    {
        if (steeringWheel != null)
        {
            Debug.Log("Slider percentage: " + steeringWheel.SlidePercentage);
        }
    }
}
