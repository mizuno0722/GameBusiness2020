using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Player2 player2;
    BouManager2 boumanager2;
    public enum GameState
    {
        Title,
        Game,
        Gameclear,
        Gameover,
    }
    public GameState state;
    private bool onetimeflg;

    void Start()
    {
        player2 = Player2.instance;
        boumanager2 = BouManager2.instance;
        state = GameState.Title;
        onetimeflg = true;//一度だけ実行させる用
    }

    void Update()
    {

        if (state == GameState.Game)
        {
            GameObject.Find("TapUI").SetActive(false);
            if (player2 == null)
                player2 = GameObject.Find("Player").GetComponent<Player2>();
            if (player2.IsGameOver())
                state = GameState.Gameover;

            if (boumanager2 == null)
                boumanager2 = GameObject.Find("BouManager").GetComponent<BouManager2>();
            if (boumanager2.IsClear())
                state = GameState.Gameclear;

            if (state == GameState.Gameclear)
            {
                GameObject.Find("GameClearText").GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
            if (state == GameState.Gameover)
            {
                GameObject.Find("GameOverText").GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
        }
    }
}

