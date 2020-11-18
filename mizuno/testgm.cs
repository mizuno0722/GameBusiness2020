using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Testgm : MonoBehaviour
{
    public static Testgm instance;
    StageData stageData;
    Player2 player2;
    GameManager gameManager;
    int nowStageNum;
    bool isMove;
    GameObject[] stageObject = new GameObject[2];
    float difference;
    public float moveCoefficient;

    BouManager2 bouManager2;

    private void Awake()
    {
        Application.targetFrameRate = 60; //fps
    }

    // Start is called before the first frame update
    void Start()
    {
        
        player2 = Player2.instance;
        instance = this;
        nowStageNum = 0;
        isMove = false;
        difference = 100;
        moveCoefficient = 0.05f;
        stageData = Resources.Load<StageData>("TestStageData");
        stageObject[0] = Instantiate(stageData.stage[nowStageNum]);
        bouManager2 = GameObject.Find("BouManager").GetComponent<BouManager2>();

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
                NextStage();
            }
            if (Input.GetKey(KeyCode.T))
            {
                Reset();
            }
        }
    }

    void Moving()
    {
        float x = stageObject[1].transform.position.x * moveCoefficient;
        if (x < 0.01)
        {
            isMove = false;
            Destroy(stageObject[0]);
            stageObject[0] = stageObject[1];
            stageObject[1] = null;
            nowStageNum++;
            bouManager2 = stageObject[0].transform.Find("BouManager").GetComponent<BouManager2>();
            player2 = stageObject[0].transform.Find("Player").GetComponent<Player2>();

            //bouManager2 = GameObject.Find("BouManager").GetComponent<BouManager2>();
            bouManager2.AllDefaultReset();
            player2.DefaultReset();
            gameManager.state = GameManager.GameState.Game;
            return; 

        }
        for (int i = 0; i < stageObject.Length; i++)
        {
            stageObject[i].transform.position = new Vector3(stageObject[i].transform.position.x - x, stageObject[i].transform.position.y, stageObject[i].transform.position.z);

        }
    }
    public int NextStage()
    {
        if (!(stageData.stage.Count <= nowStageNum + 1))
        {
            isMove = true;
            Vector3 position = new Vector3(difference, 0.0f, 0.0f);
            Quaternion q = new Quaternion();
            q = Quaternion.identity;

            stageObject[1] = Instantiate(stageData.stage[nowStageNum + 1], position, q);
            GameObject.Find("GameClearText").GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            GameObject.Find("GameOverText").GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            if (gameManager == null) gameManager = GameManager.instance;
            gameManager.state = GameManager.GameState.Moving;
            return 0;
        }
        else
        {
            return -1;
        }
    }
    public void Reset()
    {
        if (bouManager2 == null) bouManager2 = BouManager2.instance;
        bouManager2.AllReset();
        if (player2 == null) player2 = Player2.instance;
        player2.Reset();
    }
}
