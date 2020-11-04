using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bou2 : MonoBehaviour
{

    Transform tf;
    Vector3 defaultTransform;

    float timer;
    float stoptime;
    int counter;
    public float fallDownTime = 3.0f;   //default
    public float growingTime = 2.0f;      //default
    public float eraseTime = 2.0f;        //default

    float objectHeight;

    public enum Type
    {
        blue,
        red,
        none
    };
    private Type type;
    
    public enum State
    {
        Grow,
        Normal,
        FallDown,
        Erase,
    }
    State state;

    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        timer = 0;
        defaultTransform = tf.position;
        type = Type.blue;
        gameObject.GetComponent<Renderer>().material.SetFloat("_Mode", 3);
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
        
        state = State.Normal;

        objectHeight = gameObject.GetComponent<Renderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.time;
        switch (state)
        {
            case State.Grow:
                if(stoptime == 0)
                {
                    stoptime = Time.time + growingTime;
                }
                var transform = gameObject.GetComponent<Transform>();
                float y = defaultTransform.y +  -objectHeight * ((stoptime - timer) / growingTime);
                transform.position = new Vector3(defaultTransform.x, y , defaultTransform.z);
                //transform.position = new Vector3(defaultTransform.x, transform.position.y, defaultTransform.z);
                //transform.position += new Vector3(0.0f, 1.0f / (float)growingFrame, 0.0f);
                tf.rotation = new Quaternion(0, 0, 0, 0);

                if (timer > stoptime)//Nomal init
                {
                    state = State.Normal;
                    gameObject.layer = 0; //default
                    tf.position = defaultTransform;
                    transform.position = defaultTransform;
                    gameObject.GetComponent<Rigidbody>().useGravity = true;
                }
                break;

            case State.Normal:
                var rot = tf.rotation;
                if (!(rot.x * rot.x < 0.1 && rot.z * rot.z < 0.1))
                {
                    stoptime = Time.time + fallDownTime;
                    state = State.FallDown;
                }
                break;

            case State.FallDown:
                if (timer > stoptime) //erase init
                {
                    state = State.Erase;
                    stoptime = Time.time + fallDownTime;
                }
                break;

            case State.Erase:
                   
                Color color = gameObject.GetComponent<Renderer>().material.color;
                float a = 1 * ((stoptime - timer) / eraseTime);
                gameObject.GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, a);
                //gameObject.GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b , color.a - 1 / (float)eraseFrame);
                if (timer > stoptime)
                {
                    state = State.Grow;
                    gameObject.layer = LayerMask.NameToLayer("Growing");
                    gameObject.GetComponent<Rigidbody>().useGravity = false;
                    tf.position = defaultTransform + new Vector3(0.0f, -1.0f, 0.0f);
                    tf.rotation = new Quaternion(0, 0, 0, 0);
                    TypeToggle();
                    stoptime = 0;
                }
                break;
        }
        if(transform.position.y < -50)
        {
            state = State.Grow;
            gameObject.layer = LayerMask.NameToLayer("Growing");
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            tf.position = defaultTransform + new Vector3(0.0f, -1.0f, 0.0f);
            tf.rotation = new Quaternion(0, 0, 0, 0);
            TypeToggle();
            stoptime = Time.time + growingTime;
        }
    }
    int TypeToggle()
    {
        if (type == Type.blue)
        {
            type = Type.red;
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            return 0;
        }
        if (type == Type.red)
        {
            type = Type.blue;
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
            return 0;
        }
        return -1;
    }

    public Type GetType()
    {
        return type;
    }

    public void DefaultReset()
    {
        defaultTransform = tf.position;
    }
}
