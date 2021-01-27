using System.Collections;
using System.Collections.Generic;
using System.IO;
//using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    Player2 player2;
    BouManager2 boumanager2;
    public AudioClip clearsound;
    AudioSource audiosource;
    Testgm testgm;
    public GameObject titleui;
    public GameObject buttonui;
    public GameObject gameoverui;
    [SerializeField]
    public Material material;
    public GameObject kamifubuki;

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
    bool oldMouseButton0;
    private bool onetimeflg;
    private bool operationflg;

    void Start()
    {
        instance = this;
        player2 = Player2.instance;
        boumanager2 = BouManager2.instance;
        testgm = Testgm.instance;
        state = GameState.Title;
        onetimeflg = true;//一度だけ実行させる用
        operationflg = false;//
        //gameoverui.SetActive(false);
        audiosource = GetComponent<AudioSource>();
        Screen.SetResolution(1080, 1920, Screen.fullScreen);
    }

    void Update()
    {
        switch (state)
        {
            case GameState.Title:
                kamifubuki.SetActive(false);
                TitleArrive();
                Time.timeScale = 1;
                break;

            case GameState.Game:
                operationflg = false;
                buttonui.SetActive(true);
                Time.timeScale = 1;
                if (oldState != state) break;
                if (player2 == null) player2 = GameObject.Find("Player").GetComponent<Player2>();
                if (boumanager2 == null) boumanager2 = GameObject.Find("BouManager").GetComponent<BouManager2>();

                if (player2.IsGameOver() || boumanager2.IsGameOver())
                {
                    state = GameState.Gameover;
                    GameObject.Find("GameOverText").GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                }

                if (boumanager2.IsClear())
                {
                    audiosource.PlayOneShot(clearsound);
                    state = GameState.Gameclear;
                    kamifubuki.SetActive(true);
                    GameObject.Find("GameClearText").GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                }
                break;
            
            case GameState.Gameclear:
                Invoke("InvokeOperation", 1.5f);
                Time.timeScale = 1;   
                if (Input.GetMouseButton(0)&&operationflg == true)
                {
                    if (testgm == null) testgm = Testgm.instance;
                    if(testgm.NextStage() == -1)
                    {
                        SceneManager.LoadScene("Endroll");//最終ステージクリア
                    }
                    
                    kamifubuki.SetActive(false);
                    operationflg = false;
                }
                break;

            case GameState.Gameover:

                buttonui.SetActive(false);
                Invoke("InvokeOperation",0.25f);               
                Time.timeScale = 0.1f;
                //gameoverui.SetActive(true);
                if (Input.GetMouseButton(0)&&operationflg == true)

                {
                    if (testgm == null) testgm = Testgm.instance;
                    testgm.Reset();
                    state = GameState.Title;
                    operationflg = false;
                }
                break;
        }
        oldState = state;
        oldMouseButton0 = Input.GetMouseButton(0);
    }
    void TitleArrive()
    {
        titleui.SetActive(true);
        buttonui.SetActive(true);
        operationflg = false;
    }
    public void SetMaterial(GameObject player)
    {
        player.GetComponent<Renderer>().material = material;
    }
    void InvokeOperation()
    {
        operationflg = true;
    }
}

