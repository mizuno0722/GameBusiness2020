using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouManager : MonoBehaviour
{
    bou[] bous;
    static BouManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        bous = new bou[instance.transform.childCount];
        for(int i = 0; i < bous.Length; i++)
        {
            bous[i] = instance.transform.GetChild(i).GetComponent<bou>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        int count = 0;
        for(int i = 0; i < bous.Length; i++)
        {
            if(bous[i].GetType() == bou.Type.red)
            {
                count++;
            }
        }
        if (bous.Length * 0.9 < count)
        {
            //クリア
            Debug.Log("クリア");
        }
    }
}
