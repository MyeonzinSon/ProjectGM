using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseFloor : MonoBehaviour {
    BoxCollider2D area;
    EdgeCollider2D platform;

    void Start(){
        area = GetComponent<BoxCollider2D>();
        platform = GetComponent<EdgeCollider2D>();

        OnEnabled();
    }
    void OnEnabled(){
        area.isTrigger = true;
        platform.isTrigger = false;
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.DownArrow) && !platform.isTrigger){
            platform.isTrigger = true;
        }
    }
    void OnTriggerStay2D(Collider2D other){
        var player = other.GetComponent<Player>();
        if (player != null){
            platform.isTrigger = true;
        }
        else {
            return;
        }
    }
    void OnTriggerExit2D(Collider2D other){
        var player = other.GetComponent<Player>();
        if (player != null){
            platform.isTrigger = false;
        }
        else {
            return;
        }
    }
}