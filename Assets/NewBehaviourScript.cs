using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 1;
    public float jumpForce = 100;
    bool isOnGround;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        isOnGround = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = transform.position + new Vector3(-0.1f * speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
            transform.position = transform.position + new Vector3(0.1f * speed, 0, 0);

        if (Input.GetKey(KeyCode.UpArrow) && isOnGround)
        {
            isOnGround = false;
            rb.AddForce(new Vector2(0,jumpForce));
            //transform.position = transform.position + new Vector3(0, 0.1f * speed, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOnGround = true;
    }
}  

