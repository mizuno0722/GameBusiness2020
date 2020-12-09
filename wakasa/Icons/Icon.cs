using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : MonoBehaviour {
    public GameObject player;
    public Material icon;
    GameManager gamemanager;

    // Start is called before the first frame update
    void Start(){
        gamemanager = GameManager.instance;
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void OnChick(){
        player = null;

        if (player == null){
            player = GameObject.Find("Player");
            player.GetComponent<Renderer>().material = icon;
            gamemanager.material = icon;
        }
      

    }
}
