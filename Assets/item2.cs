﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var hungrySlider = FindObjectOfType<HungrySliderController>();
        hungrySlider.hungry += -30;
        var temperatureSlider = FindObjectOfType<TemperatureSliderController>();
        temperatureSlider.temperature += 30;
        Destroy(gameObject);

    }
}