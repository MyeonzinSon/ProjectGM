using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 4;
    public float jumpForce = 150;
    public int inventory = 0;
    bool isOnGround;
    Rigidbody2D rb;
    Animator anim;
    internal static Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        isOnGround = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = transform.position + new Vector3(-0.1f * speed, 0, 0);
            anim.SetBool("iswalking", true);

            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = transform.position + new Vector3(0.1f * speed, 0, 0);
            anim.SetBool("iswalking", true);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            anim.SetBool("iswalking", false);
        }
        if (Input.GetKey(KeyCode.UpArrow) && isOnGround)
        {
            isOnGround = false;
            anim.SetBool("isJumping", true);
            rb.AddForce(new Vector2(0,jumpForce));
            //transform.position = transform.position + new Vector3(0, 0.1f * speed, 0);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOnGround = true;
        anim.SetBool("isJumping", false);
    }
}  

