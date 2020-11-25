using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bou2 : MonoBehaviour
{
    //11/11
    //Growにて物理演算でオブジェクトを動かしたときの挙動調整が上手くいかない為タイマー使ってません
    Transform tf;
    public AudioClip sound1;
    AudioSource audiosource;
    Vector3 defaultTransform;
    float defaultRotationY;
    Quaternion defaultRotation;
    [SerializeField]Type defaultType = Type.blue;
    float timer;
    float stoptime;
    int counter;
    public float fallDownTime = 3.0f;   //default
    public float growingTime = 1.0f;      //default
    public float eraseTime = 1.0f;        //default

    float objectHeight;

    Vector3 testpos;

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
        audiosource = GetComponent<AudioSource>();
        tf = GetComponent<Transform>();
        timer = 0;
        DefaultReset();
        type = defaultType;
        gameObject.GetComponent<Renderer>().material.SetFloat("_Mode", 3);
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
        
        state = State.Normal;

        objectHeight = gameObject.GetComponent<Renderer>().bounds.size.y + 0.0f;

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
                    counter = 1;
                }
                testpos += new Vector3(0.0f, objectHeight / 100.0f, 0.0f);

                GetComponent<Rigidbody>().MovePosition(testpos);
                tf.rotation = defaultRotation;

                //if (timer > stoptime)//Nomal init
                if (counter >= 100) //debug
                {
                    state = State.Normal;
                    gameObject.layer = 0; //default
                    tf.position = defaultTransform;
                    gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    //tf.rotation = new Quaternion(0, defaultRotationY, 0, 0);
                    tf.rotation = defaultRotation;
                    gameObject.GetComponent<Rigidbody>().useGravity = true;
                    gameObject.GetComponent<Rigidbody>().isKinematic = false;
                }
                counter++;
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
                    GrowInit();
                }
                break;
        }
        if(tf.position.y < -50)
        {
            GrowInit();
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
        defaultTransform = tf.position + new Vector3(0.0f,0.02f,0.0f);
        defaultRotation = tf.rotation;
        defaultRotationY = tf.rotation.y;
    }
    
    private void GrowInit()
    {
        state = State.Grow;
        gameObject.layer = LayerMask.NameToLayer("Growing");
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        tf.position = defaultTransform + new Vector3(0.0f, -objectHeight, 0.0f);
        tf.rotation = defaultRotation;
        TypeToggle();
        stoptime = 0;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        testpos = defaultTransform + new Vector3(0.0f, -objectHeight, 0.0f);
    }
    public void Reset()
    {

        timer = 0;
        type = defaultType;
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
        state = State.Normal;
        gameObject.layer = 0; //default
        tf.position = defaultTransform;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        tf.rotation = defaultRotation;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("obj"))
        {
            audiosource.PlayOneShot(sound1);
            //obj to obj hit
        }
        if (collision.gameObject.name.Contains("player"))
        {
            audiosource.PlayOneShot(sound1);
            //obj to player
        }


    }
}
