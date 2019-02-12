using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 4;
    public float jumpForce = 150;
    public int inventory = 0;
    bool isOnGround;
    Rigidbody2D rb;
    Animator anim;
    GameObject cameraGO;
    public GameObject background;

    // Start is called before the first frame update
    void Awake()
    {
        PlayerStats.Initialize();
    }
    void Start()
    {
        isOnGround = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        cameraGO = FindObjectOfType<Camera>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = transform.position + Time.deltaTime * speed * Vector3.left;
            anim.SetBool("iswalking", true);

            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = transform.position + Time.deltaTime * speed * Vector3.right;
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

        SetCameraBackgroundPosition();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOnGround = true;
        anim.SetBool("isJumping", false);
    }
    void SetCameraBackgroundPosition(){
        cameraGO.transform.position = new Vector3(transform.position.x, cameraGO.transform.position.y, cameraGO.transform.position.z);
        background.transform.position = new Vector3(transform.position.x, background.transform.position.y, background.transform.position.z);
    }

}  

