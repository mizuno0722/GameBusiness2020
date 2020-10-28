using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testgm : MonoBehaviour
{
    StageData stageData;

    // Start is called before the first frame update
    void Start()
    {
        stageData = Resources.Load<StageData>("TestStageData");
        Instantiate(stageData.stage[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
