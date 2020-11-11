using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour{
    
    private Transform myTrasnform;
    private Vector3 velocity;
    public  float speed;
    // Start is called before the first frame update
   
    void Start(){
        myTrasnform = this.transform; 
        velocity = myTrasnform.position;
    }

    // Update is called once per frame
    void Update(){

        if (Input.GetKey(KeyCode.UpArrow)){
            velocity.z += speed;
        }
        if (Input.GetKey(KeyCode.RightArrow)){
            velocity.x += speed;
        }
        if (Input.GetKey(KeyCode.DownArrow)){
            velocity.z -= speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow)){
            velocity.x -= speed;
        }

        myTrasnform.position = velocity;
    }
}
