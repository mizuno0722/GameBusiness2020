using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player2 : MonoBehaviour
{
    public static Player2 instance;
    float speed = 2;
    float maxSpeed = 10;

    Vector3 defaultTransform;

    Rigidbody rb;

    Vector2 mouse;
    int mousef = 0;

    bool gameOverFlag;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody>();
        gameOverFlag = false;
        defaultTransform = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButton(0))
        {
            if (mousef == 0)
            {
                mouse = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                mousef = 1;
            }
            float x = Input.mousePosition.x - mouse.x;
            float y = Input.mousePosition.y - mouse.y;
            if (x > maxSpeed) x = maxSpeed;
            if (x < -maxSpeed) x = -maxSpeed;
            if (y > maxSpeed) y = maxSpeed;
            if (y < -maxSpeed) y = -maxSpeed;


            var movement = new Vector3(x, 0, y);
            rb.AddForce(movement * speed);
        }
        else
        {
            mousef = 0;

            var moveHorizontal = Input.GetAxis("Horizontal");
            var moveVertical = Input.GetAxis("Vertical");

            var movement = new Vector3(moveHorizontal, 0, moveVertical);

            rb.AddForce(movement * speed * 10);

        }
        //y < 10
        if (this.gameObject.transform.position.y < -10 && gameOverFlag == false)
        {
            gameOverFlag = true;
        }
        //debug reset
        if (Input.GetKey(KeyCode.R))
        {
            Reset();
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("bou"))
        {
            bou2 bou = collision.gameObject.GetComponent<bou2>();
            if(bou.GetType() == bou2.Type.red)
            {
                gameOverFlag = true;
            }
        }
    }

    public bool IsGameOver()
    {
        return gameOverFlag;
    }
    public void DefaultReset()
    {
        defaultTransform = gameObject.GetComponent<Transform>().position + new Vector3(0.0f, 0.02f, 0.0f);
    }
    public void Reset()
    {
        this.transform.position = defaultTransform;
        this.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        rb.velocity = Vector3.zero;
    }

}
