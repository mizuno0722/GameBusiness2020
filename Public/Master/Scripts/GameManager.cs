using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    Player2 player2;
    BouManager2 boumanager2;
    public AudioClip clearsound;
    AudioSource audiosource;
    Testgm testgm;
    public GameObject titleui;
    public Material material;

    public enum GameState
    {
        Title,
        Game,
        Gameclear,
        Gameover,
        Moving,
    }
    public GameState state;
    GameState oldState;
    private bool onetimeflg;

    void Start()
    {
        instance = this;
        player2 = Player2.instance;
        boumanager2 = BouManager2.instance;
        testgm = Testgm.instance;
        state = GameState.Title;
        onetimeflg = true;//一度だけ実行させる用
        audiosource = GetComponent<AudioSource>();
    }

    void Update()
    {
        switch (state)
        {
            case GameState.Title:
                TitleArrive();            
                break;

            case GameState.Game:
                if (oldState != state) break;
                if (player2 == null) player2 = GameObject.Find("Player").GetComponent<Player2>();
                if (player2.IsGameOver())
                {
                    state = GameState.Gameover;
                    GameObject.Find("GameOverText").GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                }

                if (boumanager2 == null) boumanager2 = GameObject.Find("BouManager").GetComponent<BouManager2>();
                if (boumanager2.IsClear())
                {
                    audiosource.PlayOneShot(clearsound);
                    state = GameState.Gameclear;
                    GameObject.Find("GameClearText").GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                }
                break;
            
            case GameState.Gameclear:
                    
                if (Input.GetMouseButton(0))
                {
                    if (testgm == null) testgm = Testgm.instance;
                    testgm.NextStage();
                }

                    break;
            case GameState.Gameover:
                if (Input.GetMouseButton(0))
                {
                    if (testgm == null) testgm = Testgm.instance;
                    testgm.Reset();
                    state = GameState.Title;
                }
                break;
        }
        oldState = state;
    }
    void TitleArrive()
    {
        titleui.SetActive(true);
    }
    public void SetMaterial(GameObject player)
    {
        player.GetComponent<Renderer>().material = material;
    }
}

