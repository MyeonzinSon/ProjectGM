using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 4;
    public float jumpForce = 150;
    public int inventory = 0;
    bool isOnGround {
        get { return PlayerStats.isOnGround; }
        set {
            anim.SetBool("isJumping", !value);
            PlayerStats.isOnGround = value; }
    }
    bool isWalking {
        get { return PlayerStats.isWalking; }
        set {
            anim.SetBool("iswalking", value);
            PlayerStats.isWalking = value;
        }
    }
    Rigidbody2D rb;
    Animator anim;
    GameObject cameraGO;
    public GameObject background;

    // Start is called before the first frame update
    void Awake()
    {
        PlayerStats.Initialize();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        isOnGround = false;
        cameraGO = FindObjectOfType<Camera>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = transform.position + Time.deltaTime * speed * Vector3.left;
            isWalking = true;

            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = transform.position + Time.deltaTime * speed * Vector3.right;
            isWalking = true;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            isWalking = false;
        }

        if (Input.GetKey(KeyCode.UpArrow) && isOnGround)
        {
            isOnGround = false;
            rb.AddForce(new Vector2(0,jumpForce));
        }

        SetCameraBackgroundPosition();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOnGround = true;
    }
    void SetCameraBackgroundPosition(){
        var cameraX = transform.position.x;
        if (cameraX < -10){
            cameraX = -10;
        }
        else if (cameraX > 400){
            cameraX = 400;
        }
        cameraGO.transform.position = new Vector3(cameraX, cameraGO.transform.position.y, cameraGO.transform.position.z);
    

        var offset = new Vector3(6 * ((cameraGO.transform.position.x + 10) / 400) - 3, 0, 0);
        background.transform.position = new Vector3(cameraGO.transform.position.x, background.transform.position.y, background.transform.position.z) - offset;
    }
}  

