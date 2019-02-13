using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemperatureSliderController : MonoBehaviour
{
    public int temperatureDecAmount = 2;
    public float temperatureDecTime = 10;
    float temperatureTimer;
    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = PlayerStats.GetTemperatureRatio();

        if(PlayerStats.canMove){
            temperatureTimer += Time.deltaTime;
        }

        if(temperatureTimer >= temperatureDecTime)
        {
            if (PlayerStats.temperature > 0)
            {
                PlayerStats.temperature -= temperatureDecAmount;
            }
            else
            {
                PlayerStats.hp -= 1;
            }
            temperatureTimer -= temperatureDecTime;
        }
    }
}
