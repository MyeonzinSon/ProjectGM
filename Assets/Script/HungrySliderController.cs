using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungrySliderController : MonoBehaviour
{   
    public int hungryDecAmount = 4;
    public float hungryDecTime = 10;
    float hungryTimer;
    Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = PlayerStats.GetHungryRatio();

        if(PlayerStats.canMove){
            hungryTimer += Time.deltaTime;
        }
        
        if(hungryTimer >= hungryDecTime)
        {
            if (PlayerStats.hungry > 0)
            {
                PlayerStats.hungry -= hungryDecAmount;
            }
            else
            {
                PlayerStats.hp -= 1;
            }
            hungryTimer -= hungryDecTime;
        }
    }
}
