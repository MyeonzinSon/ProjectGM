using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeDoor : MonoBehaviour
{
    bool isWithPlayer;
    GameObject indicator;
    // Start is called before the first frame update
    void Start()
    {
        isWithPlayer = false;
        indicator = GetComponentInChildren<Indicator>().gameObject;

        indicator.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isWithPlayer){
            if(!indicator.activeInHierarchy){
                indicator.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.Space) && PlayerStats.CheckAndUseItem(ItemType.Pincer)){
                SFX.PlayFix();
                PlayerStats.canRideHelicopter = true;
                Destroy(gameObject);
            }
        }
        else {
            if(indicator.activeInHierarchy){
                indicator.SetActive(false);
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
}
