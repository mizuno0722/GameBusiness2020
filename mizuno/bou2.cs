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
    public int growingFrame = 200;//default
    public int eraseFrame = 200;//default
    

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
        

        //gameObject.GetComponent<Material>().
        state = State.Normal;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Grow:
               
                if(counter == 0)
                {
                    gameObject.layer = LayerMask.NameToLayer("Growing");
                    gameObject.GetComponent<Rigidbody>().useGravity = false;
                    tf.position = defaultTransform + new Vector3(0.0f, -1.0f, 0.0f);
                    tf.rotation = new Quaternion(0, 0, 0, 0);
                    TypeToggle();
                }
                var transform = gameObject.GetComponent<Transform>();
                transform.position += new Vector3(0.0f, 1.0f / (float)growingFrame, 0.0f);

                if (growingFrame == counter)
                {
                    state = State.Normal;
                    timer = 0;
                    counter = 0;
                    gameObject.layer = 0; //default
                    gameObject.GetComponent<Rigidbody>().useGravity = true;
                }
                counter++;
                break;

            case State.Normal:
                var rot = tf.rotation;
                if (!(rot.x * rot.x < 0.1 && rot.z * rot.z < 0.1))
                {
                    //Debug.Log("倒れた");
                    //Destroy(this.gameObject);
                    if (timer == 0)
                    {
                        stoptime = Time.time + 3;
                        timer = Time.time;
                    }
                    state = State.FallDown;
                }
                break;

            case State.FallDown:
                timer += Time.deltaTime;
                if (timer > stoptime)
                {
                    state = State.Erase;
                    counter = 0;
                }
                break;

            case State.Erase:
                Color color = gameObject.GetComponent<Renderer>().material.color;
                gameObject.GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b , color.a - 1 / (float)eraseFrame);
                counter++;
                if(counter > eraseFrame)
                {
                    state = State.Grow;
                    counter = 0;
                }
                break;
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
