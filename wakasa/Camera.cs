using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class Camera : MonoBehaviour {

    public GameObject player;
    public GameObject cameraObj;
    private Vector3 initialPos;
    private Vector3 zoomPos = new Vector3(0, 5, -3);
    private Vector3 offset;

    bool zoominNow = false;
    bool tartgetChange = true;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = cameraObj.transform.position;  //初期位置保存
        offset = this.transform.position - cameraObj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //追跡するターゲットの変更
        if (Input.GetKeyDown(KeyCode.Space)) tartgetChange = !tartgetChange;

        //次のステージに行くと初期位置に
        if (Input.GetKeyDown(KeyCode.N))
        {
            player = null;
            zoominNow = false;
            cameraObj.transform.position = initialPos;
        }

        //オブジェクトを探す
        if (player == null) player = GameObject.Find("Player");

        if (Input.GetKeyDown(KeyCode.C)) Zoomin();


        if (tartgetChange)
        {
            player.SetActive(true);
            cameraObj.SetActive(false);
            this.transform.position = player.transform.position + offset;
        }
        else
        {
            player.SetActive(false);
            cameraObj.SetActive(true);
            this.transform.position = cameraObj.transform.position + offset;
        }

    }

    //ステージクリアごとに呼ぶ
    void Zoomin()
    {
        zoominNow = true;
        offset = new Vector3(0, 5, -3);
    }
}
