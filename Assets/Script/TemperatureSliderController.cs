using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemperatureSliderController : MonoBehaviour
{
    public int temperature = 0;
    public int temperatureDecAmount = 2;
    public float temperatureDecTime = 10;
    float timer;
    public int maxtemperature = 100;
    Slider slider;
    HpSlider hp;

    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        hp = FindObjectOfType<HpSlider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = (float)temperature / maxtemperature;

        timer = timer + Time.deltaTime;
        if(timer >= temperatureDecTime)
        {
            if (temperature > 0)
            {
                temperature = temperature - temperatureDecAmount;
            }
            else
            {
                hp.HP -= 1;
            }
            temperature = temperature - temperatureDecAmount;
            timer = timer - temperatureDecTime;
        }
    }
}
