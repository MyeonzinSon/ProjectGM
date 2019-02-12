using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemUI : MonoBehaviour
{
    Image image;
    Text numText;
    void Start(){
        image = GetComponent<Image>();
        image.sprite = null;

        numText = GetComponentInChildren<Text>();
        numText.text = "";
    }

    public void SetImage(Sprite sprite){
        if (sprite == null){
            image.color = new Color(1,1,1,0);
        }
        else {
            image.sprite = sprite;
            image.color = new Color(1,1,1,1);
        }
    }
    public void SetNumText(int num){
        numText.text = num.ToString();
    }
}
