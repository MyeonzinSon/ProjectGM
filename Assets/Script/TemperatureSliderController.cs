using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemperatureSliderController : MonoBehaviour
{
    public int temperature = 0;
    public int maxtemperature = 100;
    Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = (float)temperature / maxtemperature;
    }
}
