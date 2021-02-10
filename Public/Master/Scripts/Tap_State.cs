using System;
using System.Reflection;
//using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tap_State : MonoBehaviour
{
    GameObject gamemanager_object;
    GameManager gamemanager_script;
    public GameObject titleui;
    Player2 player2;
    BouManager2 bouManager2;

    void Start()
    {
        gamemanager_object = GameObject.Find("GameManager");
        gamemanager_script = gamemanager_object.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Screen_Tap(gamemanager_script.state);
    }

    public void Screen_Tap(Enum state)//ボタン以外をクリック
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
           return;
        }
        //状態によってタップ時の処理を変える
        if (Input.GetMouseButton(0))
        { 
            switch (state)
            {
                case GameManager.GameState.Title://タイトル画面でタップされた処理
                    gamemanager_script.state = GameManager.GameState.Game;
                    if (player2 == null) player2 = GameObject.Find("Player").GetComponent<Player2>();
                    player2.moveflg = true;
                    titleui.SetActive(false);
                    GameObject.Find("StageNumText").GetComponent<Text>().text = "";
                    if (bouManager2 == null) bouManager2 = GameObject.Find("BouManager").GetComponent<BouManager2>();
                    bouManager2.AllGrow();
                    break;

                case GameManager.GameState.Gameover://ゲームオーバー時にタップされた処理

                    break;

            }
        }
    }
}
