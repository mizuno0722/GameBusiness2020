﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour {

    [SerializeField]
    private GameObject player;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
       // offset = this.transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update(){
        if(player == null){
            player = GameObject.Find("Player");
            this.transform.position = player.transform.position;
            offset = this.transform.position - player.transform.position;

        }

        this.transform.position = player.transform.position + offset;
    }

}
