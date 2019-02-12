using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sp : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;

    void Start()
    {
        player = FindObjectOfType<Player>().gameObject;    
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        
    }
}
