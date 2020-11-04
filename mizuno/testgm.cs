using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testgm : MonoBehaviour
{
    StageData stageData;
    int nowStageNum;
    bool isMove;

    // Start is called before the first frame update
    void Start()
    {
        nowStageNum = 0;
        isMove = false;
        stageData = Resources.Load<StageData>("TestStageData");
        Instantiate(stageData.stage[nowStageNum]);
    }

    // Update is called once per frame
    void Update()
    {

        //debug
        if (Input.GetKey(KeyCode.RightArrow))
        {
            isMove = true;

        }
    }
}
