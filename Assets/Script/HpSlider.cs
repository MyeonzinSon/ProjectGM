using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HpSlider : MonoBehaviour
{
    public int HP = 0;
    public int MaxHP = 5;
    Slider slider;
    public Image heart1, heart2, heart3, heart4, heart5;

    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        slider.value = (float)HP / MaxHP;

        Color color;
        color = gameObject.GetComponent<Image>().color;
        color = new Color(1,0,0);
        */
        heart5.gameObject.SetActive(false);
        if (HP == 5)
        {
            heart5.gameObject.SetActive(true);
            heart4.gameObject.SetActive(true);
            heart3.gameObject.SetActive(true);
            heart2.gameObject.SetActive(true);
            heart1.gameObject.SetActive(true);
        }
        else if (HP == 4)
        {
            heart5.gameObject.SetActive(false);
            heart4.gameObject.SetActive(true);
            heart3.gameObject.SetActive(true);
            heart2.gameObject.SetActive(true);
            heart1.gameObject.SetActive(true);
        }
        else if (HP == 3)
        {
            heart5.gameObject.SetActive(false);
            heart4.gameObject.SetActive(false);
            heart3.gameObject.SetActive(true);
            heart2.gameObject.SetActive(true);
            heart1.gameObject.SetActive(true);
        }
        else if (HP == 2)
        {
            heart5.gameObject.SetActive(false);
            heart4.gameObject.SetActive(false);
            heart3.gameObject.SetActive(false);
            heart2.gameObject.SetActive(true);
            heart1.gameObject.SetActive(true);
        }
        else if (HP == 1)
        {
            heart5.gameObject.SetActive(false);
            heart4.gameObject.SetActive(false);
            heart3.gameObject.SetActive(false);
            heart2.gameObject.SetActive(false);
            heart1.gameObject.SetActive(true);
        }
        else if (HP == 0)
        {
            heart5.gameObject.SetActive(false);
            heart4.gameObject.SetActive(false);
            heart3.gameObject.SetActive(false);
            heart2.gameObject.SetActive(false);
            heart1.gameObject.SetActive(false);
            SceneManager.LoadScene("GameOver");
        }
    }
}
