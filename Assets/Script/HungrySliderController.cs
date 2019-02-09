using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungrySliderController : MonoBehaviour
{
    public int hungry = 0;
    public int hungryDecAmount = 4;
    public float hungryDecTime = 10;
    float timer;
    public int maxHungry = 100;
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
        slider.value = (float)hungry / maxHungry;

        timer = timer + Time.deltaTime;
        if(timer >= hungryDecTime)
        {
            if (hungry > 0)
            {
                hungry = hungry - hungryDecAmount;
            }
            else
            {
                hp.HP -= 1;
            }
            timer = timer - hungryDecTime;
        }
    }
}
