using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {
    Eatable,
    Wheat, Egg,
    Key, Gasoline, Tail, Pincer

}
public class Item : MonoBehaviour
{
    public ItemType type = ItemType.Eatable;
    public int hungryChange;
    public int temperatureChange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();
        if (player != null){
            if (type == ItemType.Eatable){
                PlayerStats.AddHungry(hungryChange);
                PlayerStats.AddTemperature(temperatureChange);
                Destroy(gameObject);
            }
            else{
                PlayerStats.AddInventory(this);
                Destroy(gameObject);
            }
        }
    }
    public Sprite GetSprite(){
        return GetComponent<SpriteRenderer>().sprite;
    }
}
