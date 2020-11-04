﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testgm : MonoBehaviour
{
    StageData stageData;
    int nowStageNum;
    bool isMove;
    GameObject[] stageObject = new GameObject[2];
    float difference;
    public float moveCoefficient;

    BouManager2 bouManager2;


    // Start is called before the first frame update
    void Start()
    {
        bouManager2 = BouManager2.instance;
        nowStageNum = 0;
        isMove = false;
        difference = 100;
        moveCoefficient = 0.05f;
        stageData = Resources.Load<StageData>("TestStageData");
        stageObject[0] = Instantiate(stageData.stage[nowStageNum]);

    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            Moving();
        }


        //debug
        if(!isMove)
        {
            if (Input.GetKey(KeyCode.N))
            {
                if (!(stageData.stage.Count <= nowStageNum + 1))
                {
                    isMove = true;
                    Vector3 position = new Vector3(difference, 0.0f, 0.0f);
                    Quaternion q = new Quaternion();
                    q = Quaternion.identity;

                    stageObject[1] = Instantiate(stageData.stage[nowStageNum + 1], position, q);
                }
            }
        }
    }

    void Moving()
    {
        float x = stageObject[1].transform.position.x * moveCoefficient;
        if (x < 0.01)
        {
            x = stageObject[1].transform.position.x;
            isMove = false;
            Destroy(stageObject[0]);
            stageObject[0] = stageObject[1];
            stageObject[1] = null;
            nowStageNum++;
//            bouManager2 = GameObject.Find("boumanager").GetComponent<BouManager2>();
//            bouManager2.AllDefaultReset();
            return; 

        }
        for (int i = 0; i < stageObject.Length; i++)
        {
            stageObject[i].transform.position = new Vector3(stageObject[i].transform.position.x - x, stageObject[i].transform.position.y, stageObject[i].transform.position.z);

        }
    }
}
