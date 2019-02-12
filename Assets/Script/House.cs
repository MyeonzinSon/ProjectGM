using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    bool isPlayerEntered;
    CapsuleCollider2D area;
    BoxCollider2D door;
    public GameObject floor1;
    public GameObject floor2;
    public Sprite spriteInit, spriteEntered, spriteExited;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        area = GetComponent<CapsuleCollider2D>();
        door = GetComponent<BoxCollider2D>();
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteInit;
        isPlayerEntered = false;
        PlayerOutside();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){
        var player = other.GetComponent<Player>();
        if (player != null && !isPlayerEntered){
            spriteRenderer.sprite = spriteEntered;
            isPlayerEntered = true;
            PlayerInside();
        }
    }
    void OnTriggerExit2D(Collider2D other){
        var player = other.GetComponent<Player>();
        if (player != null && isPlayerEntered){
            spriteRenderer.sprite = spriteExited;
            isPlayerEntered = false;
            PlayerOutside();
        }
    }
    void PlayerOutside(){
        floor1.SetActive(false);
        floor2.SetActive(false);
        area.enabled = false;
        door.enabled = true;
    }
    void PlayerInside(){
        floor1.SetActive(true);
        floor2.SetActive(true);
        area.enabled = true;
        door.enabled = false;
    }
}
