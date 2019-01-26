using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungrySliderController : MonoBehaviour
{
    public int hungry = 0;
    public int maxHungry = 100;
    Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = (float)hungry / maxHungry;
    }
}
