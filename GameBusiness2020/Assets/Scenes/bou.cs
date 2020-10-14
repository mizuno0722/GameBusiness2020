using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bou : MonoBehaviour
{

    Transform tf;
    Vector3 defaultTransform;

    float timer;
    float stoptime;

    public enum Type
    {
        blue,
        red,
        none
    };
    private Type type;/*
    public Type type{
       get { return this.type; }
       private  set { this.type = value; }
    }
    */
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        timer = 0;
        defaultTransform = tf.position;
        type = Type.blue;
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        var rot = tf.rotation;
        if(!(rot.x * rot.x < 0.1 && rot.z * rot.z < 0.1))
        {
            //Debug.Log("倒れた");
            //Destroy(this.gameObject);
            if (timer == 0)
            {
                stoptime = Time.time + 3;
                timer = Time.time;
            }
            timer += Time.deltaTime;
            if(timer > stoptime)
            {
                tf.position = defaultTransform;
                tf.rotation = new Quaternion(0,0,0,0);
                timer = 0;
                TypeToggle();
                //Destroy(this.gameObject);

            }
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
}

