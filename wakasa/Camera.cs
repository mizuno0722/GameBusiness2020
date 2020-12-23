using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Build;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public static Camera instance;
    public GameObject player;
    public GameObject cameraObj;
    private Vector3 initialPos;
    private Vector3 zoomPos = new Vector3(0, 6, -3.5f);
    private Vector3 offset;
    private Vector3 initialOffset;
    private Vector3 zoomOffset;
    private Vector3 destination;
    public bool isStageMove;
    private bool oldisStageMove;
    private bool isMove = false;
    bool zoominNow = false;
    bool tartgetChange = true;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        initialPos = this.transform.position;  //初期位置保存
        initialOffset = offset = this.transform.position - cameraObj.transform.position;
        zoomOffset = new Vector3(0, 5, -3);
    }

    // Update is called once per frame
    void Update()
    {
        //追跡するターゲットの変更
        if (Input.GetKeyDown(KeyCode.Space)) tartgetChange = !tartgetChange;



        //オブジェクトを探す
        if (player == null) player = GameObject.Find("Player");
        if (oldisStageMove == true && isStageMove == false)
        {
            isMove = true;
            destination = initialOffset;
        }
        if (isMove)
        {
            if (zoominNow)
            {


                 destination = player.transform.position + zoomOffset;

                //this.transform.position = player.transform.position + zoomOffset;
            }
            else
            {
                destination = player.transform.position + initialOffset;
                //this.transform.position = player.transform.position + initialOffset;
            }
            MoveCamera();

        }
        else
        {
            if (zoominNow)
            {


               // destination = zoomOffset;
                this.transform.position = player.transform.position + zoomOffset;
            }
            else
            {
                this.transform.position = player.transform.position + initialOffset;
            }
        }
        if (!isStageMove)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                /*if (!zoominNow) Zoomin();
                else Reset();*/
                ZoomToggle();
            }
           


           
        }
        else
        {
            transform.position = initialPos;
        }
        /* if (tartgetChange){
             //player.SetActive(true);
             cameraObj.SetActive(false);
             this.transform.position = player.transform.position + offset;
         }
         else{
            // player.SetActive(false);
             cameraObj.SetActive(true);
             this.transform.position = cameraObj.transform.position + offset;
         }*/
        oldisStageMove = isStageMove;
    }

    /* public void Reset()
     {
         zoominNow = false;
         offset = initialOffset;
        // cameraObj.transform.position = initialPos;
     }

     */
    private void MoveCamera(){
        Vector3 movingDistance = Vector3.Scale(destination - this.transform.position , new Vector3 (0.1f, 0.1f, 0.1f));
    if(movingDistance.x  <  0.05f && movingDistance.y < 0.05f && movingDistance.z < 0.05f)
        {
            isMove = false;
            movingDistance = destination;
            destination = Vector3.zero;
            return;
        }
        this.transform.position += movingDistance;
    }


    private void ZoomToggle()
    {
        isMove = true;

        if (zoominNow == false)
        {
            zoominNow = true;
            destination = zoomOffset;
        }
        else
        {
            zoominNow = false;
            destination = initialOffset;
        }

    }

    //ステージクリアごとに呼ぶ
    void Zoomin()
    {
        zoominNow = true;
        offset = new Vector3(0, 5, -3);
    }
    public void ResetInitialPos(Vector3 _playerpos)
    {
        initialPos = _playerpos + initialOffset;
    }
}
