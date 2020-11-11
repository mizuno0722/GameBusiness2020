using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class Camera : MonoBehaviour {
    public GameObject player;
    public GameObject cameraObj;
    private Vector3 offset;

    bool tartgetChange = true;

    // Start is called before the first frame update
    void Start(){
        offset = this.transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.Space)){
            tartgetChange = !tartgetChange;
        }

        if (tartgetChange){
            player.SetActive(true);
            cameraObj.SetActive(false);
            this.transform.position = player.transform.position + offset;
        }
        else{
            player.SetActive(false);
            cameraObj.SetActive(true);
            this.transform.position = cameraObj.transform.position + offset;
        }
    }
}
