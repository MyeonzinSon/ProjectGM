using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour
{
    public Sprite[] cuts;
    SpriteRenderer spriteRenderer;
    float timer;
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = cuts[index];
        timer = 0;
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 2.5f)
        {  
            index++;
            if(index < cuts.Length){
                spriteRenderer.sprite = cuts[index];
                timer -= 2f;
            }
            else{
                SceneManager.LoadScene("GamePlay");
            }
        }
    }
}
