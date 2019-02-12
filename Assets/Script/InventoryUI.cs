using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InventoryUI : MonoBehaviour
{
    static InventoryUI instance;
    ItemUI[] invUIs;
    void Start(){
        invUIs = GetComponentsInChildren<ItemUI>();
        foreach (var invUI in invUIs){
            invUI.SetImage(null);
        }
        instance = this;
    }

    public static void UpdateUI(){
        for (int i = 0; i < PlayerStats.inventories.Count; i++){
            var itemInfo = PlayerStats.inventories[i];
            instance.invUIs[i].SetImage(itemInfo.sprite);
            instance.invUIs[i].SetNumText(itemInfo.num);
        }
    }
}
