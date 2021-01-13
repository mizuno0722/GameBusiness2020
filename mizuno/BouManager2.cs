using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouManager2 : MonoBehaviour
{
    bou2[] bous;
    public static BouManager2 instance;
    bool clearFlag;
    bool isGameOver;
    GaugeManager gaugeManager;
    int oldCount;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        bous = new bou2[instance.transform.childCount];
        for(int i = 0; i < bous.Length; i++)
        {
            bous[i] = instance.transform.GetChild(i).GetComponent<bou2>();
        }
        gaugeManager = GameObject.Find("Gauge").GetComponent<GaugeManager>();
        gaugeManager.InitFillAmount();
        clearFlag = false;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        int count = 0;
        for(int i = 0; i < bous.Length; i++)
        {
            if(bous[i].GetType() == bou2.Type.red)
            {
                count++;
            }
            if (bous[i].GetIsGameOver())
            {
                isGameOver = true;
            }
        }
        if(oldCount != count)
        {

            float from = gaugeManager.GetFillAmount();
            float to = (float)count / bous.Length;
            StartCoroutine(gaugeManager.RedGaugeReduction(to, from, 0.5f));
            Debug.Log("from:" + from + "  to:" + to);
        }
        if (bous.Length * 0.9 < count)
        {
            //クリア
            clearFlag = true;        }
        else
        {
            clearFlag = false;
        }
        oldCount = count;
    }
    public bool IsClear()
    {
        return clearFlag;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public void AllDefaultReset()
    {
        for (int i = 0; i < bous.Length; i++)
        {
            bous[i].DefaultReset();
        }
    }
    public void AllReset()
    {
        for (int i = 0; i < bous.Length; i++)
        {
            bous[i].Reset();
        }
        clearFlag = false;
        isGameOver = false;
    }
}
