using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : MonoBehaviour {
    public GameObject player;
    public Material icon;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void OnChick(){
        if(player == null){
            player = GameObject.Find("Player");
            player.GetComponent<Renderer>().material = icon; 
        }
      

    }
}
