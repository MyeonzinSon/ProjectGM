using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeHelicopter : MonoBehaviour
{
    bool isWithPlayer;
    bool isEnding{
        get { return !PlayerStats.canMove; }
        set { PlayerStats.canMove = !value; }
    }
    public GameObject tail, gasoline, key;
    SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    int spriteIndex;
    public float acceleration;
    Vector2 speed;
    int magicNum; //3 tail 2 gasoline 1 key 0 escape;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        isWithPlayer = false;
        magicNum = 3;
        tail.SetActive(false);
        gasoline.SetActive(false);
        key.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(!PlayerStats.canRideHelicopter) return;
        if(!isEnding){
            if (magicNum > 0){
                if (isWithPlayer){
                    if (!ChooseIndicator().activeInHierarchy){
                        ChooseIndicator().SetActive(true);
                    }
                    if (Input.GetKeyDown(KeyCode.Space) && magicNum >= 1 && RightItem()){
                        SFX.PlayFix();
                        ChooseIndicator().SetActive(false);
                        magicNum--;
                        if(magicNum > 0){
                            ChooseIndicator().SetActive(true);
                        }
                        else {
                            Ending();
                        }
                    }
                }
                else {
                    if (ChooseIndicator().activeInHierarchy){
                        ChooseIndicator().SetActive(false);
                    }
                }
            }
        }
        else {
            spriteIndex++;
            if (!(spriteIndex < sprites.Length)){
                spriteIndex = 0;
            }
            spriteRenderer.sprite = sprites[spriteIndex];
            speed += new Vector2(acceleration * Time.deltaTime / -2, acceleration * Time.deltaTime);
            transform.Translate(speed * Time.deltaTime);
            
            if(transform.position.y > 10){
                SceneManager.LoadScene("GameClear");
            }
        }
    }
    bool RightItem(){
        if (magicNum == 3 && PlayerStats.CheckAndUseItem(ItemType.Tail)){
            return true;
        }
        else if (magicNum == 2 && PlayerStats.CheckAndUseItem(ItemType.Gasoline)){
            return true;
        }
        else if (magicNum == 1 && PlayerStats.CheckAndUseItem(ItemType.Key)) {
            return true;
        }
        else {
            return false;
        }

    }
    GameObject ChooseIndicator(){
        switch(magicNum){
            case 3 : {
                return tail;
            }
            case 2 : {
                return gasoline;
            }
            case 1 : {
                return key;
            }
            default : {
                return null;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        var player = other.GetComponent<Player>();
        if (player != null){
            isWithPlayer = true;
        }
    }
    void OnTriggerExit2D(Collider2D other){
        var player = other.GetComponent<Player>();
        if (player != null){
            isWithPlayer = false;
        }
    }
    void Ending(){
        isEnding = true;
        speed = Vector2.zero;
        SFX.PlayHelicopter();
    }
}
